using Microsoft.AspNetCore.DataProtection.KeyManagement;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HangFire.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {
            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("teomangungoren@gmail.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("beyzagungoren@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
