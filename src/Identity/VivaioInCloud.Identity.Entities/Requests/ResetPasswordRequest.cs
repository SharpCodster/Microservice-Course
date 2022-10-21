namespace VivaioInCloud.Identity.Entities.Requests
{
    public class ResetPasswordRequest
    {
        public string? Email { get; set; }
        public string? Token { get; set; }
        public string? NewPasword { get; set; }
    }
}
