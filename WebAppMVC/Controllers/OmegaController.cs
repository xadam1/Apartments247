using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC.Controllers
{
    public class OmegaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
    }
}
