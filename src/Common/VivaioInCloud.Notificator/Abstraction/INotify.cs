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
