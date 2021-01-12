using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace WebAppMVC.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult About(int userId, int groupId)
        {
            AboutModel m = new AboutModel()
            {
                UserId = userId,
                GroupId = groupId,
            };
            return View(m);
        }
    }
}
