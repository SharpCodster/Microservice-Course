using VivaioInCloud.Common.Entities.Dtos;

namespace VivaioInCloud.Identity.Entities.Dtos
{
    public class ApplicationUserDtoRead : BaseAuditableDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }


        public bool IsDomainlUser { get; set; }
        public bool IsActive { get; set; }

        public long? InstallerId { get; set; }

        public ICollection<ApplicationRoleDtoRead>? IdentityRoles { get; set; }
    }

    public class ApplicationUserDtoWrite
    {
        public bool TwoFactorEnabled { get; set; }
        public bool IsActive { get; set; }
        public long? InstallerId { get; set; }
    }
}
