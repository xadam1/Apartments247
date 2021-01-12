using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace WebAppMVC.Controllers
{
    public class ListUnitsController : Controller
    {
        [HttpGet]
        public IActionResult ListUnits(int userId, int groupId)
        {
            ListUnitsModel m = new ListUnitsModel()
            {
                UserId = userId,
                GroupId = groupId,
                Groups = Utils.Utils.GetUnitGroupNamesByUserId(userId),
                Units = Utils.Utils.GetUnitsByUnitGroupId(groupId),
            };

            return View(m);
        }
    }
}
