using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using MVC.Models;
using DAL.Extras;
using System.Net.Http;
using Newtonsoft.Json;
using WebAPI.Models;

namespace MVC.Controllers
{
    public class DeltaController : Controller
    {
        private const int userId = 1;
        private const string apiUrl = "http://cassiopeia.serveirc.com:5000/";

        public IActionResult Index()
        {
            return RedirectToAction("Overview", "Delta");
        }

        public IActionResult Overview()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListGroups()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage respond = client.GetAsync(apiUrl + $"GetUnitGroupsByUserId?userId={userId}").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    UnitGroupWithSpecificationModel[] groups = JsonConvert.DeserializeObject<UnitGroupWithSpecificationModel[]>(content);
                    ListGroupsModel m = new ListGroupsModel()
                    {
                        Groups = groups
                    };
                    return View(m);
                }
            }
        }

        [HttpGet]
        public IActionResult ListUnits(int groupId = -1)
        {
            ListUnitsModel m = new ListUnitsModel();
            
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage respond = client.GetAsync(apiUrl + $"GetUnitGroupNamesByUserId?userId={userId}").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    m.Groups = JsonConvert.DeserializeObject<UnitGroupNameModel[]>(content);
                }

                if (groupId == -1 && m.Groups.Length > 0)
                {
                    groupId = m.Groups.First().Id;
                }
                m.UnitGroupId = groupId;

                using (HttpResponseMessage respond = client.GetAsync(apiUrl + $"GetUnitsByUnitGroupId?groupId={groupId}").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    m.Units = JsonConvert.DeserializeObject<UnitWithSpecificationModel[]>(content);
                }

                return View(m);
            }
        }

        [HttpGet]
        public IActionResult EditGroup(int groupId = -1)
        {
            EditGroupModel m = new EditGroupModel();

            using (HttpClient client = new HttpClient())
            {
                if (groupId == -1)
                {
                    m.Group = new UnitGroupWithSpecificationModel()
                    {
                        Id = -1,
                        UserId = userId,
                        Name = "Výzkumné středisko CERN",
                        ColorId = -1,
                        Note = "Hadronový urychlovač částic a další věci"
                    };
                }
                else
                {
                    using (HttpResponseMessage respond = client.GetAsync(apiUrl + $"GetUnitGroupById?groupId={groupId}").Result)
                    {
                        string content = respond.Content.ReadAsStringAsync().Result;
                        UnitGroupWithSpecificationModel group = JsonConvert.DeserializeObject<UnitGroupWithSpecificationModel>(content);
                        m.Group = group;
                    }
                }

                using (HttpResponseMessage respond = client.GetAsync(apiUrl + $"GetColors").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    Color[] colors = JsonConvert.DeserializeObject<Color[]>(content);
                    m.Colors = colors;
                }
            }

            return View(m);
        }

        [HttpGet]
        public IActionResult EditUnit(int groupId, int unitId)
        {
            EditUnitModel m = new EditUnitModel();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage respond = client.GetAsync(apiUrl + $"GetUnitById?unitId={unitId}").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    UnitWithSpecificationModel unit = JsonConvert.DeserializeObject<UnitWithSpecificationModel>(content);
                    m.Unit = unit;
                }

                using (HttpResponseMessage respond = client.GetAsync(apiUrl + $"GetColors").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    Color[] colors = JsonConvert.DeserializeObject<Color[]>(content);
                    m.Colors = colors;
                }
            }

            return View(m);
        }

        [HttpPost]
        public IActionResult SaveGroup(int groupId, string name, int colorSelect, string note)
        {
            using (HttpClient client = new HttpClient())
            {
                UnitGroupWithSpecificationModel m = new UnitGroupWithSpecificationModel()
                {
                    Id = groupId,
                    Name = name,
                    ColorId = colorSelect,
                    Note = note
                };
                using (HttpResponseMessage respond = client.GetAsync(apiUrl + $"SaveUnitGroup?userId={userId}&groupId={groupId}&name={name}&colorId={colorSelect}&note={note}").Result)
                {
                    string c = respond.Content.ReadAsStringAsync().Result;
                    groupId = JsonConvert.DeserializeObject<int>(c);
                }
            }

            return RedirectToAction($"EditGroup", "Delta", new { groupId = groupId });
        }

        [HttpPost]
        public IActionResult SaveUnit(int groupId, int unitId, string name, int selectColor, string note)
        {
            using (HttpClient client = new HttpClient())
            {
                UnitWithSpecificationModel m = new UnitWithSpecificationModel()
                {

                };
            }

                return RedirectToAction();
        }
    }
}
