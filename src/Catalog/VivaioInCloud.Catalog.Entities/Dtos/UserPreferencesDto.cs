using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaioInCloud.Catalog.Entities.Models;
using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Catalog.Entities.Dtos
{
    public class UserPreferencesDtoRead : IIdentified, IUserOwnedRecord
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public virtual ItemTypeDtoRead ItemType { get; set; }
    }

    public class UserPreferencesDtoWrite
    {
        public string ItemTypeId { get; set; }
    }
}
