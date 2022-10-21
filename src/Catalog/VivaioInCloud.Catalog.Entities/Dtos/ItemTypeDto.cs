using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
