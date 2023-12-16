using Microsoft.AspNetCore.Mvc;

namespace PhisingTestPlatform.UI.Controllers
{
    public class EmailTemplatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
