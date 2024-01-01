using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhishingTestPlatform.Data;
using PhishingTestPlatform.Data.Models;

namespace PhishingTestPlatform.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly PhishingDbContext _context;
        public UserController(PhishingDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(User user)
        {
            var admin = await _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefaultAsync();

            if (admin != null)
            {
                CookieOptions options = new CookieOptions();
                Response.Cookies.Append("Username", admin.Username, options);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Username or password is invalid!";
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("Username");
            return RedirectToAction("Index", "User");
        }
    }
}
