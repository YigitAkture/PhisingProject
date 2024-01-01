using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhishingTestPlatform.Data;

namespace PhishingTestPlatform.UI.Controllers
{
    public class SendPhishingEmailController : Controller
    {
        private readonly PhishingDbContext _context;
        public SendPhishingEmailController(PhishingDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.EmailTemplates.OrderBy(x => x.TemplateName).ToListAsync());
        }
    }
}
