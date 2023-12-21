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

        [HttpGet("Spotify")]
        public IActionResult SpotifyLogin()
        {
            return View("SpotifyLogin");
        }

        [HttpGet("Netflix")]
        public IActionResult NetflixLogin()
        {
            return View("NetflixLogin");
        }

        [HttpGet("Twitter")]
        public IActionResult TwitterLogin()
        {
            return View("TwitterLogin");
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
