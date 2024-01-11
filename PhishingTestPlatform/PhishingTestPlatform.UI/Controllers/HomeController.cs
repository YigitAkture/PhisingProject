using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhishingTestPlatform.Data;
using PhishingTestPlatform.UI.Constants;
using PhishingTestPlatform.UI.Models;
using PhishingTestPlatform.UI.Services;
using PhishingTestPlatform.UI.Views.Models;
using System.Diagnostics;

namespace PhishingTestPlatform.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhishingDbContext _context;
        private readonly IEmailService _emailService;

        public HomeController(PhishingDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ViewData["PhisingInfos"] = await _context.PhishingInfo.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).Include(x => x.PhishingEmailSend).ThenInclude(x => x.EmailTemplates).Select(x => new PhishingUserInfoViewModel
            {
                Name = $"{x.FirstName} {x.LastName}",
                Email = x.Email,
                Password = x.Password,
                CreditCardNumber = x.CreditCardNumber,
                CreditCardExpirationDate = $"{ x.CreditCardExpirationDateMonth.ToString("00") } / { x.CreditCardExpirationDateYear }",
                CreditCardCVV = x.CreditCardCVV,
                Source = x.PhishingEmailSend.EmailTemplates.TemplateName
            }).ToListAsync();

            // Total counts
            ViewData["TotalCount"] = await _context.PhishingEmailsSend.CountAsync();
            ViewData["ClickedCount"] = await _context.PhishingEmailsSend.CountAsync(x => x.IsClicked);
            ViewData["NotClickedCount"] = await _context.PhishingEmailsSend.CountAsync(x => !x.IsClicked);

            // Clicked email count per template
            ViewData["NetflixClickedCount"] = await _context.PhishingEmailsSend.Include(x => x.EmailTemplates).CountAsync(x => x.IsClicked && x.EmailTemplates.TemplateName == "Netflix");
            ViewData["SpotifyClickedCount"] = await _context.PhishingEmailsSend.Include(x => x.EmailTemplates).CountAsync(x => x.IsClicked && x.EmailTemplates.TemplateName == "Spotify");
            ViewData["TwitterClickedCount"] = await _context.PhishingEmailsSend.Include(x => x.EmailTemplates).CountAsync(x => x.IsClicked && x.EmailTemplates.TemplateName == "Twitter");
            
            // Sent email count per template
            ViewData["NetflixEmailSentCount"] = await _context.PhishingEmailsSend.Include(x => x.EmailTemplates).CountAsync(x => x.Status == (int)EmailStatus.Sent && x.EmailTemplates.TemplateName == "Netflix");
            ViewData["SpotifyEmailSentCount"] = await _context.PhishingEmailsSend.Include(x => x.EmailTemplates).CountAsync(x => x.Status == (int)EmailStatus.Sent && x.EmailTemplates.TemplateName == "Spotify");
            ViewData["TwitterEmailSentCount"] = await _context.PhishingEmailsSend.Include(x => x.EmailTemplates).CountAsync(x => x.Status == (int)EmailStatus.Sent && x.EmailTemplates.TemplateName == "Twitter");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
