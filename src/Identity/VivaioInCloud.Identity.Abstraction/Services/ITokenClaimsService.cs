using System.Security.Claims;
using VivaioInCloud.Identity.Model.Models;

namespace VivaioInCloud.Identity.Abstraction.Services
{
    public interface ITokenClaimsService
    {
        TokenData GenerateAuthTokenAsync(List<Claim> claims);
        TokenData GenerateRefreshTokenAsync();
        ClaimsPrincipal ValidateAccessToken(string accessToken);
    }
}
