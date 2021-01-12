using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using WebAppMVC.Utils;

namespace WebAppMVC.Controllers
{
    public class ListGroupsController : Controller
    {
        [HttpGet]
        public IActionResult ListGroups(int groupId)
        {
            ListGroupsModel m = new ListGroupsModel()
            {
                UserId = UserManager.UserId,
                GroupId = groupId,
                Groups = Utils.Utils.GetUnitGroupsByUserId(),
            };
            return View(m);
        }
    }
}
