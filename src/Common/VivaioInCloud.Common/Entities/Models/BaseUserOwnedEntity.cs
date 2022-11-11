using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Entities.Models
{
    public class BaseUserOwnedEntity : BaseEntity, IUserOwnedRecord
    {
        public string OwnerId { get; set; }
    }
}
