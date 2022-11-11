using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Notification.Entities.Models
{
    public class UserNotification : BaseAuditableEntity
    {
        public string Message { get; set; }
        public string UserId { get; set; }
        public bool Delivered { get; set; }

        public virtual Contact? User { get; set; }
    }
}
