using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;
using WebAPI.Models;
using System.Net.Http;
using Newtonsoft.Json;
using DAL.Models;

namespace MVC.Controllers
{
    public class EditUnitController : Controller
    {
        [HttpGet]
        public IActionResult EditUnit(int userId, int groupId, int unitId=-1)
        {
            EditUnitModel m = new EditUnitModel()
            {
                UserId = userId,
                GroupId = groupId,
                UnitId = unitId,
            };

            using (HttpClient client = new HttpClient())
            {
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
                    using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitById?unitId={unitId}").Result)
                    {
                        string content = respond.Content.ReadAsStringAsync().Result;
                        UnitWithSpecificationModel unit = JsonConvert.DeserializeObject<UnitWithSpecificationModel>(content);
                        m.Unit = unit;
                    }
                }

                using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetColors").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    Color[] colors = JsonConvert.DeserializeObject<Color[]>(content);
                    m.Colors = colors;
                }

                using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitTypes").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    UnitTypeModel[] unitTypes = JsonConvert.DeserializeObject<UnitTypeModel[]>(content);
                    m.UnitTypes = unitTypes;
                }

                using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitGroupNamesByUserId?userId={userId}").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    UnitGroupNameModel[] unitGroups = JsonConvert.DeserializeObject<UnitGroupNameModel[]>(content);
                    m.UnitGroups = unitGroups;
                }
            }

            return View(m);
        }

        [HttpPost]
        public IActionResult SaveUnit(int userId, int unitId, int groupId, string name, int selectColor, string note, int selectUnitType, int currentCapacity, int maxCapacity, string contractLink, string state, string city, string street, string number, string zip)
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
                string commandUrl = $"SaveUnit?groupId={groupId}&unitId={unitId}&name={name}&colorId={selectColor}&note={note}&unitTypeId={selectUnitType}&currentCapacity={currentCapacity}&maxCapacity={maxCapacity}&contractLink={contractLink}&state={state}&city={city}&street={street}&number={number}&zip={zip}";
                using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + commandUrl).Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    unitId = JsonConvert.DeserializeObject<int>(content);
                }
            }

            return RedirectToAction($"EditUnit", "EditUnit", new { userId = userId, groupId = groupId, unitId = unitId });
        }
    }
}
