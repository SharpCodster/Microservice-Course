using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Notification.Entities.Models
{
    public class UserPreference : BaseEntity
    {
        public string UserId { get; set; }
        public string TypeId { get; set; }

        public virtual Contact? User { get; set; }
    }
}
