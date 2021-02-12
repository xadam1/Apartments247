using System.Diagnostics;
using System.Threading.Tasks;
using BLL.Facades;
using DAL.Extras;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;
using WebMVC.Utils;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserFacade _userFacade;

        public HomeController(ILogger<HomeController> logger, IUserFacade userFacade)
        {
            _logger = logger;
            _userFacade = userFacade;
        }

        public IActionResult Index()
        {
            if (UserInfoManager.UserId == Constants.NO_ID)  // not logged in
            {
                if (User.Identity.Name != null) // autologin
                {
                    UserInfoManager.SetUserIdByUsername(User.Identity.Name);
                }
            }

            return RedirectToAction("About", "Home");
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}