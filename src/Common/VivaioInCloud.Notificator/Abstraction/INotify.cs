using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Notificator.Models;

namespace VivaioInCloud.Notificator.Abstraction
{
    public interface INotify
    {
        Task SendEmailAsync(SendEmailRequest mail, CancellationToken cancellationToken = default);


        Task NotifyUserPreferenceChangedAsync(UserPreferencesMessage message);


        Task NotifyNewUserCreatedAsync(NewUserCreated newUSer);
    }
}
