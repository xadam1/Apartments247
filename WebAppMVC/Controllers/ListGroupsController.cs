using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebAPI.Models;
using Newtonsoft.Json;
using MVC.Models;

namespace MVC.Controllers
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
                Groups = Utils.GetUnitGroupsByUserId(userId),
            };
            return View(m);
        }
    }
}
