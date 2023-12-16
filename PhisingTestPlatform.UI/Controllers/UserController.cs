using Microsoft.AspNetCore.Mvc;

namespace PhishingTestPlatform.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create()
        {
            return View("CreditCardInformation");
        }

        public IActionResult CreditCard()
        {
            return View();
        }

        [HttpPost("SubmitCreditCard")]
        public IActionResult SubmitCreditCard()
        {
            return View("Error");
        }
    }
}
