using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(int userId = -1, int groupId = -1)
        {
            if (userId == -1)
            {
                userId = 40; // TODO
            }
            if (groupId == -1)
            {
                groupId = Utils.GetFirstUnitGroupIdByUserId(userId);
            }

            return RedirectToAction("Overview", "Overview", new { userId = userId, groupId = groupId });
        }

        [HttpGet]
        public IActionResult Privacy(int userId, int groupId)
        {
            HomeModel m = new HomeModel()
            {
                UserId = userId,
                GroupId = groupId,
            };
            return View(m);
        }
    }
}
