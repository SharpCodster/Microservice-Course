using VivaioInCloud.Common.Entities.Dtos;

namespace VivaioInCloud.Identity.Entities.Dtos
{
    public class ApplicationRoleDtoRead : BaseAuditableDto
    {
        public string Name { get; set; }
    }

    public class ApplicationRoleDtoWrite
    {
        public string Name { get; set; }
    }
}
