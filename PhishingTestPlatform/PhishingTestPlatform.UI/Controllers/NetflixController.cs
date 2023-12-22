using Microsoft.AspNetCore.Mvc;

namespace PhishingTestPlatform.UI.Controllers
{
    public class NetflixController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreditCard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return RedirectToAction("CreditCard");
        }

        [HttpPost]
        public IActionResult CreditCardSubmit()
        {
            return RedirectToAction("Index", "Error");
        }
    }
}
