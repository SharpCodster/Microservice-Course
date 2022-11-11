namespace VivaioInCloud.Common.Options
{
    public class AccessTokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpirationHours { get; set; }
        public int RefreshTokenExpirationDays { get; set; }
    }
}
