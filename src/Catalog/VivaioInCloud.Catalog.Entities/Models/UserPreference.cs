using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Catalog.Entities.Models
{
    public class UserPreference : BaseUserOwnedEntity
    {
        public string ItemTypeId { get; set; }

        public virtual ItemType? ItemType { get; set; }
    }
}
