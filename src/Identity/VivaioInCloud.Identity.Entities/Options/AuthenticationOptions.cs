namespace VivaioInCloud.Identity.Entities.Options
{
    public sealed class AuthenticationOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpirationHours { get; set; }
        public int RefreshTokenExpirationDays { get; set; }
    }
}
