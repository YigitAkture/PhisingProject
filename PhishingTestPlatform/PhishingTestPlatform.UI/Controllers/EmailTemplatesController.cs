using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhishingTestPlatform.Data;
using PhishingTestPlatform.Data.Models;

namespace PhishingTestPlatform.UI.Controllers
{
    public class EmailTemplatesController : Controller
    {
        private readonly PhishingDbContext _context;

        public EmailTemplatesController(PhishingDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmailTemplates.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Models.EmailTemplates emailTemplates)
        {
            if (ModelState.IsValid)
            {
                var emailTemplate = new EmailTemplates
                {
                    Id = Guid.NewGuid(),
                    TemplateName = emailTemplates.TemplateName,
                    TemplateSubject = emailTemplates.TemplateSubject,
                    TemplateBody = emailTemplates.TemplateBody
                };

                _context.Add(emailTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailTemplates);
        }

        public IActionResult Edit(Guid id)
        {
            var emailTemplate = _context.EmailTemplates.FirstOrDefault(x => x.Id == id);
            var model = new Models.EmailTemplates
            {
                Id = emailTemplate.Id,
                TemplateName = emailTemplate.TemplateName,
                TemplateSubject = emailTemplate.TemplateSubject,
                TemplateBody = emailTemplate.TemplateBody
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Models.EmailTemplates emailTemplates)
        {
            if (ModelState.IsValid)
            {
                var emailTemplate = new EmailTemplates
                {
                    Id = emailTemplates.Id,
                    TemplateName = emailTemplates.TemplateName,
                    TemplateSubject = emailTemplates.TemplateSubject,
                    TemplateBody = emailTemplates.TemplateBody
                };

                _context.Update(emailTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailTemplates);
        }
    }
}
