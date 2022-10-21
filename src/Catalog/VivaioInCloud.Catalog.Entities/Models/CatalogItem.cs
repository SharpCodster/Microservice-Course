﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Catalog.Entities.Models
{
    public class CatalogItem : BaseAuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }

        public virtual ItemType? Category { get; set; }
    }
}
