using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Web;
using VivaioInCloud.Common;
using VivaioInCloud.Common.Controllers;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Api.Options;
using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Models;
using VivaioInCloud.Identity.Entities.Requests;
using VivaioInCloud.Notificator.Abstraction;
using VivaioInCloud.Notificator.Models;

namespace VivaioInCloud.Identity.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly ILogger<UserAuthenticationController> _logger;
        private readonly IUserAuthenticationManager _identityService;
        private readonly INotify _notify;
        private readonly AccountRedirectUrlsOptions _options;
        private readonly IValidator<LoginRequest> _loginValidator;
        private readonly IValidator<RefreshTokenRequest> _refreshValidator;

        public UserAuthenticationController(
            IValidator<LoginRequest> loginValidator,
            IValidator<RefreshTokenRequest> refreshValidator,
            IUserAuthenticationManager identityService,
            ILogger<UserAuthenticationController> logger,
            INotify notify,
            IOptions<AccountRedirectUrlsOptions> options
            )
        {
            _refreshValidator = refreshValidator;
            _loginValidator = loginValidator;
            _identityService = identityService;
            _logger = logger;
            _notify = notify;
            _options = options.Value;
        }

        [HttpPost]
        [Route("user-login")]
        [Tags("user-authentication")]
        public async Task<ActionResult> Login([FromBody] LoginRequest model)
        {
            ValidationResult validationResult = await _loginValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors.Select(_ => _.ErrorMessage).ToList());
            }

            var response = await _identityService.LoginAsync(model);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return Unauthorized(response);
        }

        [HttpPost]
        [Route("user-refresh")]
        [Tags("user-authentication")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
        {
            ValidationResult validationResult = await _refreshValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.Errors.Select(_ => _.ErrorMessage).ToList());
            }

            var response = await _identityService.RefreshTokenAsync(request);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("reset-password")]
        [Tags("user-authentication")]
        public async Task<IActionResult> SendResetPassword([FromBody] ResetPasswordRequest model)
        {
            var token = await _identityService.GeneratePasswordResetTokenAsync(model.Email);
            if (!String.IsNullOrEmpty(token))
            {
                var url = HttpUtility.UrlEncode(String.Format(_options.ResetPasswordUrl, token, model.Email));

                List<string> toList = new List<string>();
                toList.Add(model.Email);

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("url", url);

                SendEmailRequest mail = new SendEmailRequest()
                {
                    Action = SolutionConstants.NotificationAction.EMAIL,
                    Title = "Password Reset",
                    TemplateName = SolutionConstants.EmailTemplates.PASSWORD_RESET,
                    ToList = toList,
                    Parameters = parameters
                };

                await _notify.SendEmail(mail);
            }
            // Non comunico se lindirizzo mail non esiste
            return Ok();
        }

        [HttpPost]
        [Route("reset-password-confirmation")]
        [Tags("user-authentication")]
        public async Task<IActionResult> ConfirmResetPassword([FromBody] ResetPasswordRequest model)
        {
            var reset = await _identityService.ConfirmResetPasswordAsync(model);
            return Ok();
        }

        [HttpPost]
        [Route("send-confirmation-email")]
        [Tags("user-authentication")]
        public async Task<IActionResult> ResendConfirmation([FromBody] ConfirmEmailRequest model)
        {
            var token = await _identityService.GenerateEmailConfirmationTokenAsync(model.Email);
            if (!String.IsNullOrEmpty(token))
            {
                var url = HttpUtility.UrlEncode(String.Format(_options.ConfirmAccountUrl, token, model.Email));

                List<string> toList = new List<string>();
                toList.Add(model.Email);

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("url", url);

                SendEmailRequest mail = new SendEmailRequest()
                {
                    Action = SolutionConstants.NotificationAction.EMAIL,
                    Title = "Confirm Account",
                    TemplateName = SolutionConstants.EmailTemplates.CONFIRM_ACCOUNT,
                    ToList = toList,
                    Parameters = parameters
                };

                await _notify.SendEmail(mail);
            }
            // Non comunico se lindirizzo mail non esiste
            return Ok();
        }

        [HttpPost]
        [Route("confirm-email")]
        [Tags("user-authentication")]
        public async Task<ActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest model)
        {
            var reset = await _identityService.ConfirmEmailAsync(model);
            return Ok();
        }


        [HttpPost]
        [Route("register")]
        [Tags("user-authentication")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<ActionResult> Register([FromBody] RegisterUserRequest model)
        {
            var response = await _identityService.RegisterNewUser(model);

            if (response)
            {
                var token = await _identityService.GenerateEmailConfirmationTokenAsync(model.Email);
                if (!String.IsNullOrEmpty(token))
                {
                    var url = HttpUtility.UrlEncode(String.Format(_options.ConfirmAccountUrl, token, model.Email));

                    List<string> toList = new List<string>();
                    toList.Add(model.Email);

                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("url", url);

                    SendEmailRequest mail = new SendEmailRequest()
                    {
                        Action = SolutionConstants.NotificationAction.EMAIL,
                        Title = "Confirm Account",
                        TemplateName = SolutionConstants.EmailTemplates.CONFIRM_ACCOUNT,
                        ToList = toList,
                        Parameters = parameters
                    };

                    await _notify.SendEmail(mail);
                }

                return Ok(response);
            }

            return StatusCode(StatusCodes.Status400BadRequest, response);
        }


        [HttpGet]
        [Route("deactivate")]
        [Tags("user-authentication")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.ADMIN)]
        public async Task<ActionResult> Deactivate([FromQuery] string userId)
        {

            var response = await _identityService.DeactivateUser(userId);

            if (response)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status400BadRequest, response);
        }
    }
}
