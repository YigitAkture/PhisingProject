using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhishingTestPlatform.Data;
using PhishingTestPlatform.Data.Models;
using PhishingTestPlatform.UI.Constants;
using PhishingTestPlatform.UI.Services;

namespace PhishingTestPlatform.UI.Controllers
{
    public class SendPhishingEmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly PhishingDbContext _context;
        public SendPhishingEmailController(PhishingDbContext context, IEmailService emailService)
        {
            _emailService = emailService;
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.EmailTemplates.OrderBy(x => x.TemplateName).ToListAsync());
        }

        public async Task<IActionResult> SendEmailAsync(Guid templateId, List<string> emails)
        {
            var template = await _context.EmailTemplates.FindAsync(templateId);

            foreach (var email in emails)
            {
                var phishingEmail = new PhishingEmailSend
                {
                    Email = email,
                    TemplateId = templateId,
                    EmailTemplates = template,
                    Status = (int)EmailStatus.InProgress,
                    IsClicked = false,
                };
                await _context.PhishingEmailsSend.AddAsync(phishingEmail);
                await _context.SaveChangesAsync();
                
                // send Email
                await _emailService.SendEmailAsync(email, templateId, phishingEmail.Id);

                phishingEmail.Status = (int)EmailStatus.Sent;
                _context.PhishingEmailsSend.Update(phishingEmail);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "SendPhishingEmail");
        }
    }
}
