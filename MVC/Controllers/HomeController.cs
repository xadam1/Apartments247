using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int userId = 1; // TODO
            int groupId = Utils.GetFirstUnitGroupIdByUserId(userId);

            return RedirectToAction("Overview", "Overview", new { userId = userId, groupId = groupId });
        }
    }
}
