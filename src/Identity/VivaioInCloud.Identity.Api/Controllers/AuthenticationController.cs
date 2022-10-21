using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Web;
using VivaioInCloud.Common.Controllers;
using VivaioInCloud.Identity.Abstraction.Services;
using VivaioInCloud.Identity.Entities.Dtos;
using VivaioInCloud.Identity.Entities.Models;
using VivaioInCloud.Identity.Entities.Requests;

namespace VivaioInCloud.Identity.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserAuthenticationManager _identityService;
        private readonly INotify _notify;
        private readonly AccountRedirectUrlsOptions _options;
        private readonly IValidator<LoginRequest> _loginValidator;
        private readonly IValidator<RefreshTokenRequest> _refreshValidator;

        public AuthenticationController(
            IValidator<LoginRequest> loginValidator,
            IValidator<RefreshTokenRequest> refreshValidator,
            IUserAuthenticationManager identityService,
            ILogger<AuthenticationController> logger,
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

        [AllowAnonymous]
        [HttpPost("user-refresh")]
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
        public async Task<IActionResult> ConfirmResetPassword([FromBody] ResetPasswordRequest model)
        {
            var reset = await _identityService.ConfirmResetPasswordAsync(model);
            return Ok();
        }

        [HttpPost]
        [Route("send-confirmation-email")]
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
        public async Task<ActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest model)
        {
            var reset = await _identityService.ConfirmEmailAsync(model);
            return Ok();
        }


        [HttpPost]
        [Route("register")]
        [Authorize(Roles = SolutionConstants.Authorization.Roles.BACK_OFFICE)]
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
        [Authorize(Roles = SolutionConstants.Authorization.Roles.BACK_OFFICE)]
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
