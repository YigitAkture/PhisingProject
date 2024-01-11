namespace PhishingTestPlatform.UI.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, Guid templateId, Guid phishingEmailSendId);
    }
}
