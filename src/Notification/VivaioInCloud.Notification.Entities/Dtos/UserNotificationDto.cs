using VivaioInCloud.Common.Entities.Dtos;

namespace VivaioInCloud.Notification.Entities.Dtos
{
    public class UserNotificationDtoRead : BaseAuditableDto
    {
        public string Message { get; set; }
        public ContactDtoRead User { get; set; }
        public bool Delivered { get; set; }
    }

    public class UserNotificationDtoWrite
    {
        public string Message { get; set; }
        public string UserId { get; set; }
        public bool Delivered { get; set; }
    }
}
