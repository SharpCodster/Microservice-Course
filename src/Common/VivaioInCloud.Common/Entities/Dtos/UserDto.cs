using System.Security.Claims;

namespace VivaioInCloud.Common.Entities.Dtos
{
    public class UserDto
    {
        public string? UserName { get; set; }
        public ClaimsPrincipal? Principal { get; set; }
        public IEnumerable<Claim> UserClaims { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
    }
}
