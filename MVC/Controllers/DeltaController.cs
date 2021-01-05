using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using MVC.Models;

namespace MVC.Controllers
{
    public class DeltaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListGroups()
        {
            const int userId = 14;
            ApartmentsDbContext con = new ApartmentsDbContext();
            User user = con.Users.Where(user => user.Id == userId).First();
            UnitGroup[] groups = con.UnitGroups.Where(group => group.UserId == userId).ToArray();
            ListGroupsModel m = new ListGroupsModel() { Groups = groups };
            return View(m);
        }

        public IActionResult ListUnits()
        {
            const int groupId = 8;
            ApartmentsDbContext con = new ApartmentsDbContext();
            Unit[] units = con.Units.Where(unit => unit.UnitGroupId == groupId).ToArray();
            ListUnitsModel m = new ListUnitsModel() { Units = units };
            return View(m);
        }
    }
}
