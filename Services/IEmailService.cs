namespace PwiForms.Services
{
    public interface IEmailService
    {
        void SendConfimationMail(string email, string token);
        void SendPasswordResetEmail(string email, string token);
    }
}