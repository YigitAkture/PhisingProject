using Microsoft.AspNetCore.Mvc;

namespace PhisingTestPlatform.UI.Controllers
{
    public class SendPhisingEmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
