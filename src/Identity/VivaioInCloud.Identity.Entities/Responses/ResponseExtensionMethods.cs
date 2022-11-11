using VivaioInCloud.Identity.Model.Responses;

namespace VivaioInCloud.Identity.Entities.Responses
{
    public static class ResponseExtensionMethods
    {
        public static LoginResponse MissingPassword(this LoginResponse response)
        {
            response.Message = "Perfavore inserire Password";
            return response;
        }
        public static LoginResponse MissingEmail(this LoginResponse response)
        {
            response.Message = "Perfavore inserire Email";
            return response;
        }
        public static LoginResponse InvalidEmailOrPasswor(this LoginResponse response)
        {
            response.Message = "Email o Password invalidi";
            return response;
        }
        public static LoginResponse EmailNotConfirmed(this LoginResponse response)
        {
            response.Message = "Email non confermata";
            return response;
        }
        public static LoginResponse RequireTwoFactorAuth(this LoginResponse response)
        {
            response.RequiresTwoFactor = true;
            return response;
        }
        public static LoginResponse UserNotFound(this LoginResponse response)
        {
            response.Message = "Utente non trovato";
            return response;
        }
        public static LoginResponse IncorrenctToken(this LoginResponse response)
        {
            response.Message = "Token errato o scaduto";
            return response;
        }
        public static LoginResponse InvalidrefreshToken(this LoginResponse response)
        {
            response.Message = "Refresh Token non valido";
            return response;
        }
        public static LoginResponse InvalidClientCredential(this LoginResponse response)
        {
            response.Message = "Client credential non valide";
            return response;
        }
    }
}
