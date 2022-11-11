using System.Security.Claims;

namespace VivaioInCloud.Common.Entities.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public ClaimsPrincipal? Principal { get; set; }
        public IEnumerable<Claim> UserClaims { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
    }
}
