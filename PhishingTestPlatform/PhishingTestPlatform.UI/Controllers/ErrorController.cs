using Microsoft.AspNetCore.Mvc;

namespace PhishingTestPlatform.UI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
