using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace WebAppMVC.Controllers
{
    public class ListGroupsController : Controller
    {
        [HttpGet]
        public IActionResult ListGroups(int userId, int groupId)
        {
            ListGroupsModel m = new ListGroupsModel()
            {
                UserId = userId,
                GroupId = groupId,
                Groups = Utils.Utils.GetUnitGroupsByUserId(userId),
            };
            return View(m);
        }
    }
}
