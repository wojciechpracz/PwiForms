using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MailKit;
using MimeKit;

namespace PwiForms.Services
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendConfimationMail(string email, string token)
        {
            var message = new MimeMessage();

            var appEmail = _config.GetSection("AppSettings:Email").Value;
            var emailPass = _config.GetSection("Appsettings:EmailPass").Value;
            var serverName = _config.GetSection("Appsettings:ServerName").Value;
            
            var activationLink = 
            // string.Format(@"Kliknij w podany link, aby potwierdzić swój adres email: 
            // http://{0}/User/ConfirmEmail?email={1}&token={2}", serverName, email, token);
            string.Format(@"Kliknij w podany link, aby potwierdzić swój adres email: 
            http://{0}/email-confirmation?email={1}&token={2}", serverName, email, token);

            message.To.Add(new MailboxAddress("reciever", email));
            message.From.Add(new MailboxAddress("sender", appEmail));
            message.Subject = "Aktywacja konta";
            message.Body = new TextPart("plain")
            {
                Text = activationLink
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(appEmail, emailPass);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void SendPasswordResetEmail(string email, string token)
        {
            var message = new MimeMessage();

            var appEmail = _config.GetSection("AppSettings:Email").Value;
            var emailPass = _config.GetSection("Appsettings:EmailPass").Value;
            var serverName = _config.GetSection("Appsettings:ServerName").Value;

            var activationLink = string.Format(@"Kliknij w podany link, aby zresetować hasło: 
            http://{0}/change-password?email={1}&token={2}", serverName, email, token);
            
            message.To.Add(new MailboxAddress("reciever", email));
            message.From.Add(new MailboxAddress("sender", appEmail));

            message.Subject = "Resetowanie hasła";
            message.Body = new TextPart("plain")
            {
                Text = activationLink
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(appEmail, emailPass);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}