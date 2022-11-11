namespace VivaioInCloud.Notificator.Models
{
    public class NewUserCreated
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool SendRegistrationEmail { get; set; }
        public string? EmailRegistrationToken { get; set; }
    }
}
