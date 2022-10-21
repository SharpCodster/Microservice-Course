namespace VivaioInCloud.Identity.Entities.Requests
{
    public class ConfirmEmailRequest
    {
        public string? Email { get; set; }
        public string? Code { get; set; }
    }
}
