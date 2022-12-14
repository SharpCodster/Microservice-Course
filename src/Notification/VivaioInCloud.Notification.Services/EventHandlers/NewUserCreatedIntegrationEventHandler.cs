using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Common.Abstraction.Services.EventBus;
using VivaioInCloud.Notification.Abstraction.Services;
using VivaioInCloud.Notification.Entities.Models;
using VivaioInCloud.Notification.Services.Services;
using VivaioInCloud.Notificator.Models;

namespace VivaioInCloud.Notification.Services.EventHandlers
{
    public class NewUserCreatedIntegrationEventHandler : IIntegrationEventHandler<NewUserCreated>
    {
        private readonly ILogger<NewUserCreatedIntegrationEventHandler> _logger;
        private readonly IContactService _contactService;
        private readonly IUserNotificationService _userNotificationService;

        public NewUserCreatedIntegrationEventHandler(
            ILogger<NewUserCreatedIntegrationEventHandler> logger,
            IContactService contactService, IUserNotificationService userNotificationService)
        {
            _logger = logger;
            _contactService = contactService;
            _userNotificationService = userNotificationService;
        }

        public async Task Handle(NewUserCreated @event)
        {
            _logger.LogInformation("New event");

            var newContact = new Contact()
            {
                Name = @event.Name,
                Surname = @event.Surname,
                Email = @event.Email,
            };
            var contact = await _contactService.CreateAsync(newContact);


            if (@event.SendRegistrationEmail)
            {
                var newNotification = new UserNotification()
                {
                    UserId = contact.Id,
                    Message = $"Email confirmation token: {@event.EmailRegistrationToken}",
                    Delivered = false
                };
                var notification = await _userNotificationService.CreateAsync(newNotification);
            }
        }
    }
}

