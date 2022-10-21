using VivaioInCloud.Common.Entities.Dtos;

namespace VivaioInCloud.Catalog.Entities.Dtos
{
    public class ItemTypeDtoRead : BaseAuditableDto
    {
        public string Name { get; set; }
    }

    public class ItemTypeDtoWrite
    {
        public string Name { get; set; }
    }
}
