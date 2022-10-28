using VivaioInCloud.Common.Entities.Dtos;

namespace VivaioInCloud.Identity.Entities.Dtos
{
    public class ApplicationUserDtoRead : BaseAuditableDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsActive { get; set; }

        public ICollection<ApplicationRoleDtoRead>? IdentityRoles { get; set; }
    }

    public class ApplicationUserDtoWrite
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool IsActive { get; set; }
    }


    public class RegisterUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class RegisterAdminRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

}
