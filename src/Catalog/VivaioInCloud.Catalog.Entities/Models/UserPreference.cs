using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Catalog.Entities.Models
{
    public class UserPreference : BaseUserOwnedEntity
    {
        public string ItemTypeId { get; set; }

        public virtual ItemType? ItemType { get; set; }
    }
}
