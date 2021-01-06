using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using MVC.Models;
using DAL.Extras;

namespace MVC.Controllers
{
    public class DeltaController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Overview", "Delta");
        }

        public IActionResult Overview()
        {
            // TODO
            return View();
        }

        public IActionResult ListGroups()
        {
            const int userId = 14;
            ApartmentsDbContext con = new ApartmentsDbContext();
            User user = con.Users.Where(user => user.Id == userId).First();
            UnitGroup[] groups = con.UnitGroups.Where(group => group.UserId == userId).ToArray();
            ListOfGroupsModel m = new ListOfGroupsModel() { Groups = groups };
            return View(m);
        }

        public IActionResult ListUnits()
        {
            const int groupId = 8;
            ApartmentsDbContext con = new ApartmentsDbContext();
            Unit[] units = con.Units.Where(unit => unit.UnitGroupId == groupId).ToArray();
            ListOfUnitsModel m = new ListOfUnitsModel() { Units = units };
            return View(m);
        }
        public IActionResult NewGroup()
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            UnitType[] unitTypes = con.UnitTypes.ToArray();
            NewGroupModel m = new NewGroupModel() {UnitTypes = unitTypes };
            return View(m);
        }
        public IActionResult NewUnit()
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            UnitType[] unitTypes = con.UnitTypes.ToArray();
            Color[] colors = con.Colors.ToArray();
            NewUnitModel m = new NewUnitModel() { UnitTypes = unitTypes, Colors = colors};
            return View(m);
        }

        [HttpPost]
        public IActionResult CreateGroup(string name, string colorString, string note)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();

            Color color = con.Colors.Where(c => c.Name == colorString).FirstOrDefault();

            Specification spec = new Specification()
            {
                Name = name,
                Color = color,
                //Address = ???,
                Note = note
            };

            UnitGroup group = new UnitGroup()
            {
                //User = ???,
                Specification = spec
            };

            con.UnitGroups.Add(group);

            return RedirectToAction("EditGroup", "Delta");
        }

        [HttpPost]
        public IActionResult CreateUnit(string name, string unitTypeString, string note, string currentCapacityString, string maxCapacityString, string colorString)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();

            Color color = con.Colors.Where(c => c.Name == colorString).FirstOrDefault();
            Specification spec = new Specification()
            {
                Name = name,
                Color = color,
                //AddressId = AddressId
                Note = note,
            };

            int currentCapacity = 0, maxCapacity = 0;
            int.TryParse(currentCapacityString, out currentCapacity);
            int.TryParse(maxCapacityString, out maxCapacity);
            UnitType unitType = con.UnitTypes.Where(ut => ut.Type == unitTypeString).FirstOrDefault();

            Unit unit = new Unit()
            {
                CurrentCapacity = currentCapacity,
                MaxCapacity = maxCapacity,
                Specification = spec,
                UnitType = unitType,
                //UnitGroupId = newUnit.UnitGroupId
                //ContractLink = newUnit.ContractLink,
            };

            con.Units.Add(unit);

            return RedirectToAction("EditUnit", "Delta");
        }

        public IActionResult EditUnit()
        {
            return View();
        }
    }
}
