using VivaioInCloud.Notificator.Models.Enums;

namespace VivaioInCloud.Notificator.Models
{
    public class UserPreferencesMessage
    {
        public ChangeType Change { get; set; }
        public string UserId { get; set; }
        public string PreferenceTypeId { get; set; }
    }
}
