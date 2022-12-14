using VivaioInCloud.Common.Entities.Dtos;

namespace VivaioInCloud.Notification.Entities.Dtos
{
    public class ContactDtoRead : BaseAuditableDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }

    public class ContactDtoWrite
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
