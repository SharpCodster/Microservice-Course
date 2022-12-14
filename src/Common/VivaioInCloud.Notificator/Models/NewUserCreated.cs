using VivaioInCloud.Common.Entities.Models;

namespace VivaioInCloud.Notificator.Models
{
    public record NewUserCreated : IntegrationEvent
    {
        public string UserID { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public bool SendRegistrationEmail { get; private set; }
        public string? EmailRegistrationToken { get; private set; }

        public NewUserCreated(string userID, string email, string name, 
            string surname, bool sendRegistrationEmail, string? emailRegistrationToken)
        {
            UserID = userID;
            Email = email;
            Name = name;
            Surname = surname;
            SendRegistrationEmail= sendRegistrationEmail;
            EmailRegistrationToken= emailRegistrationToken;
        }
    }
}
