using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class DeltaController : Controller
    {
        private const int userId = 1;

        public IActionResult Index()
        {
            return RedirectToAction("Overview", "Delta");
        }

        public IActionResult Overview()
        {
            return View();
        }

        public IActionResult ListGroups()
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            UnitGroup[] groups = con.UnitGroups.Where(group => group.UserId == userId).ToArray();
            ListOfGroupsModel m = new ListOfGroupsModel() { Groups = groups };
            return View(m);
        }

        public IActionResult ListUnits(int groupId = -1)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            UnitGroup[] groups = con.UnitGroups.Where(group => group.UserId == userId).ToArray();
            Unit[] units = new Unit[0];

            if (groups.Length > 0)
            {
                int specId = 0;
                if (groupId == -1)
                {
                    // Nezadáno
                    specId = groups.First().Specification.Id;
                }
                else
                {
                    // Zadáno
                    specId = groups.Where(group => group.Id == groupId).FirstOrDefault().Specification.Id;
                }
                units = con.Units.Where(unit => unit.SpecificationId == specId).ToArray();
            }

            ListOfGroupsAndUnitsModel m = new ListOfGroupsAndUnitsModel()
            {
                Groups = groups,
                Units = units
            };

            return View(m);
        }

        [HttpPost]
        public IActionResult EditGroup(int id, string name, string colorString, string note)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();

            Color color = con.Colors.Where(c => c.Name == colorString).FirstOrDefault();

            UnitGroup edited = con.UnitGroups.Where(group => group.Id == id).FirstOrDefault();
            if (edited == null)
            {
                // Vytváří se nový
                Specification spec = new Specification()
                {
                    Name = name,
                    Color = color,
                    //Address = ???,
                    Note = note
                };

                edited = new UnitGroup()
                {
                    //User = ???,
                    Specification = spec
                };

                con.UnitGroups.Add(edited);
            }
            else
            {
                edited.Specification.Name = name;
                edited.Specification.Color = color;
                edited.Specification.Note = note;
                con.UnitGroups.Update(edited);
            }

            return RedirectToAction("EditGroups", "Delta");
        }

        [HttpPost]
        public IActionResult EditUnit(int id, string name, string unitTypeString, string note, string currentCapacityString, string maxCapacityString, string colorString)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();

            Color color = con.Colors.Where(c => c.Name == colorString).FirstOrDefault();

            int currentCapacity = 0, maxCapacity = 0;
            int.TryParse(currentCapacityString, out currentCapacity);
            int.TryParse(maxCapacityString, out maxCapacity);
            UnitType unitType = con.UnitTypes.Where(ut => ut.Type == unitTypeString).FirstOrDefault();

            Unit edited = con.Units.Where(unit => unit.Id == id).FirstOrDefault();
            if (edited == null)
            {
                // Vytváří se nový
                Specification spec = new Specification()
                {
                    Name = name,
                    Color = color,
                    //AddressId = AddressId
                    Note = note,
                };

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
            }
            else
            {
                edited.CurrentCapacity = currentCapacity;
                edited.MaxCapacity = maxCapacity;
                edited.UnitType = unitType;

                edited.Specification.Name = name;
                edited.Specification.Color = color;
                edited.Specification.Note = note;

                con.Units.Update(edited);
            }

            return RedirectToAction("EditUnit", "Delta");
        }
    }
}
