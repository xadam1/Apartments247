using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;
using WebAPI.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace MVC.Controllers
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
                Groups = Utils.GetUnitGroupNamesByUserId(userId),
                Units = Utils.GetUnitsByUnitGroupId(groupId),
            };

            return View(m);
        }
    }
}
