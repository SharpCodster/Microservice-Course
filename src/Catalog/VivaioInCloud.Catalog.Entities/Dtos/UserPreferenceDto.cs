using VivaioInCloud.Common.Abstraction.Entities;

namespace VivaioInCloud.Catalog.Entities.Dtos
{
    public class UserPreferenceDtoRead : IIdentified, IUserOwnedRecord
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public virtual ItemTypeDtoRead ItemType { get; set; }
    }

    public class UserPreferenceDtoWrite
    {
        public string ItemTypeId { get; set; }
    }
}
