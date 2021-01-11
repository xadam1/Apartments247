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
    public class EditGroupController : Controller
    {


        [HttpGet]
        public IActionResult EditGroup(int userId, int groupId, int createNewInt)
        {
            bool createNew = createNewInt > 0;

            EditGroupModel m = new EditGroupModel()
            {
                UserId = userId,
                GroupId = groupId,
                CreateNew = createNew,
            };

            using (HttpClient client = new HttpClient())
            {
                if (createNew)
                {
                    m.Group = new UnitGroupWithSpecificationModel()
                    {
                        Id = -1,
                        UserId = userId,
                        Name = "Výzkumné středisko CERN",
                        ColorId = 7,
                        Note = "Hadronový urychlovač částic a další věci",
                        State = "state",
                        City = "city",
                        Street = "street",
                        Number = "number",
                        Zip = "zip",
                    };
                }
                else
                {
                    using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetUnitGroupById?groupId={groupId}").Result)
                    {
                        string content = respond.Content.ReadAsStringAsync().Result;
                        UnitGroupWithSpecificationModel group = JsonConvert.DeserializeObject<UnitGroupWithSpecificationModel>(content);
                        m.Group = group;
                    }
                }

                using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + $"GetColors").Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    Color[] colors = JsonConvert.DeserializeObject<Color[]>(content);
                    m.Colors = colors;
                }
            }

            return View(m);
        }

        [HttpPost]
        public IActionResult SaveGroup(int userId, int groupId, string name, int colorSelect, string note, string state, string city, string street, string number, string zip)
        {
            using (HttpClient client = new HttpClient())
            {
                /*
                UnitGroupWithSpecificationModel m = new UnitGroupWithSpecificationModel()
                {
                    Id = groupId,
                    Name = name,
                    ColorId = colorSelect,
                    Note = note
                };
                */

                string commandUrl = $"SaveUnitGroup?userId={userId}&groupId={groupId}&name={name}&colorId={colorSelect}&note={note}&state={state}&city={city}&street={street}&number={number}&zip={zip}";
                using (HttpResponseMessage respond = client.GetAsync(Utils.apiUrl + commandUrl).Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    groupId = JsonConvert.DeserializeObject<int>(content);
                }
            }

            return RedirectToAction($"EditGroup", "EditGroup", new { userId = userId, groupId = groupId });
        }

        [HttpGet]
        public IActionResult DeleteGroup(int userId, int groupId)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(Utils.apiUrl + $"DeleteGroup?groupId={groupId}").Result)
                {
                    // Nothing to do
                }

                using (HttpResponseMessage response = client.GetAsync(Utils.apiUrl + $"GetFirstUnitGroupIdByUserId?userId={userId}").Result)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    groupId = JsonConvert.DeserializeObject<int>(content);
                }
            }
            return RedirectToAction("ListGroups", "ListGroups", new { userId = userId, groupId = groupId });
        }
    }
}
