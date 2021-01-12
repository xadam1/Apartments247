using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace WebAppMVC.Controllers
{
    public class OverviewController : Controller
    {
        [HttpGet]
        public IActionResult Overview(int userId, int groupId)
        {
            OverviewModel m = new OverviewModel()
            {
                UserId = userId,
                GroupId = groupId,
            };
            return View(m);
        }
    }
}
