using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Newtonsoft.Json;
using System.Net.Http;
using WebAPI.Models;
using WebAppMVC.Utils;

namespace WebAppMVC.Controllers
{
    public class EditUnitController : Controller
    {
        [HttpGet]
        public IActionResult EditUnit(int groupId, int unitId = -1)
        {
            EditUnitModel m = new EditUnitModel()
            {
                UserId = UserManager.UserId,
                GroupId = groupId,
                UnitId = unitId,
                Colors = Utils.Utils.GetColors(),
                UnitTypes = Utils.Utils.GetUnitTypes(),
                UnitGroups = Utils.Utils.GetUnitGroupNamesByUserId(),
            };

            if (unitId == -1)
            {
                m.Unit = new UnitWithSpecificationModel()
                {
                    Id = -1,
                    Name = "Domeček lásky",
                    ColorId = 10,
                    State = "state",
                    City = "city",
                    Street = "street",
                    Number = "number",
                    Zip = "zip",
                    Note = "Skvělé místo pro zamilované skupiny libovolné arity",
                    UnitTypeId = 6,
                    CurrentCapacity = 0,
                    MaxCapacity = 2,
                    ContractLink = "nezadáno",
                };
            }
            else
            {
                m.Unit = Utils.Utils.GetUnitById(unitId);
            }

            return View(m);
        }

        [HttpPost]
        public IActionResult SaveUnit(int unitId, int groupId, string name, int selectColor, string note,
            int selectUnitType, int currentCapacity, int maxCapacity, string contractLink, string state, string city,
            string street, string number, string zip)
        {
            using (HttpClient client = new HttpClient())
            {
                /*
                UnitWithSpecificationModel m = new UnitWithSpecificationModel()
                {
                    Id = unitId,
                    UnitGroupId = groupId,
                    Name = name,
                    ColorId = selectColor,
                    AddressId = -1, // TODO!!!!
                    Note = note,
                    UnitTypeId = selectUnitType,
                    CurrentCapacity = currentCapacity,
                    MaxCapacity = maxCapacity,
                    ContractLink = contractLink
                };
                */
                string commandUrl = $"SaveUnit?groupId={groupId}&unitId={unitId}&name={name}&colorId={selectColor}&note={note}" +
                                    $"&unitTypeId={selectUnitType}&currentCapacity={currentCapacity}&maxCapacity={maxCapacity}" +
                                    $"&contractLink={contractLink}&state={state}&city={city}&street={street}&number={number}&zip={zip}";

                using (HttpResponseMessage respond = client.GetAsync(Utils.ApiConnectionUrls.API_URL + commandUrl).Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    unitId = JsonConvert.DeserializeObject<int>(content);
                }
            }

            return RedirectToAction("EditUnit", "EditUnit", new { groupId = groupId, unitId = unitId });
        }

        [HttpGet]
        public IActionResult DeleteUnit(int groupId, int unitId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(Utils.ApiConnectionUrls.API_URL + $"DeleteUnit?unitId={unitId}").Result)
            {
                // Nothing to do
            }

            return RedirectToAction("ListUnits", "ListUnits", new { groupId = groupId });
        }
    }
}
