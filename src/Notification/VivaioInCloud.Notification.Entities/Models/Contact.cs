using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Notification.Entities.Models
{
    public class Contact : BaseAuditableEntity
    {
        public Contact()
        {
            Notifications = new HashSet<UserNotification>();
            UserPreferences = new HashSet<UserPreference>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public virtual ICollection<UserNotification>? Notifications { get; set; }
        public virtual ICollection<UserPreference>? UserPreferences { get; set; }
    }
}
