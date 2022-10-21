using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Common.Entities.Dtos
{
    public class BaseAuditableDto : BaseDto, IAuditableUtc
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public string UpdatedBy { get; set; }
    }
}
