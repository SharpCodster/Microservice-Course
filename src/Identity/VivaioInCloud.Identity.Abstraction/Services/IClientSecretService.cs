namespace VivaioInCloud.Identity.Abstraction.Services
{
    public interface IClientSecretService
    {
        string GenerateNewAppSecret();
        string GenerateSecretHash(string secret);
        bool CheckSecret(string savedSecret, string enteredSecret);
    }
}
