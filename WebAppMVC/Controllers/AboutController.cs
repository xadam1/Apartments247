using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using WebAppMVC.Utils;

namespace WebAppMVC.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult About(int groupId)
        {
            AboutModel m = new AboutModel()
            {
                UserId = UserInfoManager.UserId,
                GroupId = groupId,
            };
            return View(m);
        }
    }
}
