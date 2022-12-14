using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VivaioInCloud.Common.Abstraction.Contexts;
using VivaioInCloud.Common.Abstraction.Services.EventBus;
using VivaioInCloud.Notificator.Abstraction;
using VivaioInCloud.Notificator.Models;
using VivaioInCloud.Notificator.Options;

namespace VivaioInCloud.Notificator.Service
{
    public class Notify : INotify
    {
        private readonly NotificationOptions _options;
        private readonly ILogger<Notify> _logger;
        private readonly IRequestContextProvider _requestContextProvider;
        private readonly IEventBus _eventBus;

        public Notify(IEventBus eventBus, IRequestContextProvider requestContextProvider, IOptions<NotificationOptions> options, ILogger<Notify> logger)
        {
            _eventBus = eventBus;
            _requestContextProvider = requestContextProvider;
            _options = options.Value;
            _logger = logger;
        }

        public async Task NotifyNewUserCreatedAsync(NewUserCreated newUSer)
        {
            var ctx = await _requestContextProvider.GetRequestContexAsync();

            NotificationRequest req = new NotificationRequest();
            req.CorrelationId = ctx.CorrelationId;
            req.UserId = ctx.User.UserName;


            _eventBus.Publish(newUSer);


            await Task.CompletedTask;
        }

        public Task NotifyUserPreferenceChangedAsync(UserPreferencesMessage message)
        {
            throw new NotImplementedException();
        }

        public async Task SendEmailAsync(SendEmailRequest mail, CancellationToken cancellationToken = default)
        {
            string output = JsonConvert.SerializeObject(mail);

            await Task.CompletedTask;
        }
    }
}
