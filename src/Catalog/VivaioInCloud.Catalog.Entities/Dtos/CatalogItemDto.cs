using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common.Entities.Dtos;

namespace VivaioInCloud.Catalog.Entities.Dtos
{
    public class CatalogItemDtoRead : BaseAuditableDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ItemTypeDtoRead? Category { get; set; }
    }

    public class CatalogItemDtoWrite
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
