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
            
            var activationLink = string.Format("http://{0}/User/ConfirmEmail?email={1}&token={2}", serverName, email, token);

            message.To.Add(new MailboxAddress("reciever", "testypwi@gmail.com"));
            message.From.Add(new MailboxAddress("sender", email));
            message.Subject = "elo melo";
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