
using System.Net.Mail;
using System.Net;
using System.Text;
using PhishingTestPlatform.Data;
using Microsoft.Extensions.Configuration;

namespace PhishingTestPlatform.UI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public readonly PhishingDbContext _context;

        public EmailService(PhishingDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, Guid templateId, Guid phishingEmailSendId)
        {
            var template = await _context.EmailTemplates.FindAsync(templateId);

            // Set up SMTP client
            SmtpClient client = new SmtpClient(_configuration.GetValue<string>("Smtp:Host"), _configuration.GetValue<int>("Smtp:Port"));
            client.EnableSsl = _configuration.GetValue<bool>("Smtp:EnableSsl");
            client.UseDefaultCredentials = _configuration.GetValue<bool>("Smtp:UseDefaultCredentials");
            client.Credentials = new NetworkCredential(_configuration.GetValue<string>("Smtp:Email"), _configuration.GetValue<string>("Smtp:Password"));

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_configuration.GetValue<string>("Smtp:Email"));
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = template.TemplateSubject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat(template.TemplateBody.Replace("{{id}}", phishingEmailSendId.ToString()));
            mailMessage.Body = mailBody.ToString();

            // Send email
            client.Send(mailMessage);
        }
    }
}
