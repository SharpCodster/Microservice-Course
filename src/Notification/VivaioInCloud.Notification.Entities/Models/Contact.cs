using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Notification.Entities.Models
{
    public class Contact : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
