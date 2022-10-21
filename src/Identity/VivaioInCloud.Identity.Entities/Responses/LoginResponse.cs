using VivaioInCloud.Identity.Model.Models;

namespace VivaioInCloud.Identity.Model.Responses
{
    public class LoginResponse
    {
        public bool Succeeded { get; set; } = false;
        public bool RequiresTwoFactor { get; set; } = false;

        public User? User { get; set; }

        public string? AccessToken { get; set; }
        public DateTime? AccessTokenExpiration { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }

        public string? Message { get; set; }
    }
}
