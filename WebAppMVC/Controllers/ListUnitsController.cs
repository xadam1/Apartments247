using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using WebAppMVC.Utils;

namespace WebAppMVC.Controllers
{
    public class ListUnitsController : Controller
    {
        [HttpGet]
        public IActionResult ListUnits(int groupId)
        {
            ListUnitsModel m = new ListUnitsModel()
            {
                UserId = UserInfoManager.UserId,
                GroupId = groupId,
                Groups = Utils.Utils.GetUnitGroupNamesByUserId(),
                Units = Utils.Utils.GetUnitsByUnitGroupId(groupId),
            };

            return View(m);
        }
    }
}
