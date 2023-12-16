using Microsoft.AspNetCore.Mvc;

namespace PhishingTestPlatform.UI.Controllers
{
    public class SendPhishingEmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
