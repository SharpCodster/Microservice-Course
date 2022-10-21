using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Entities.Models
{
    public class BaseAuditableEntity : BaseEntity, IAuditableUtc
    {
        public DateTime CreatedAtUtc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
