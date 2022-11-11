using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Entities.Models
{
    public class BaseAuditableUserOwnedEntity : BaseAuditableEntity, IUserOwnedRecord
    {
        public string OwnerId { get; set; }
    }
}
