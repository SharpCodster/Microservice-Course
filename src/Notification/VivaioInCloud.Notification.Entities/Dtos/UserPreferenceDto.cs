using VivaioInCloud.Common.Entities.Dtos;

namespace VivaioInCloud.Notification.Entities.Dtos
{
    public class UserPreferenceDtoRead : BaseDto
    {
        public string TypeId { get; set; }
        public ContactDtoRead User { get; set; }
    }

    public class UserPreferenceDtoWrite
    {
        public string TypeId { get; set; }
    }
}
