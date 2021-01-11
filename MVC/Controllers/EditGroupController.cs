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
        public IActionResult EditGroup(int userId, int groupId)
        {
            EditGroupModel m = new EditGroupModel()
            {
                UserId = userId,
                GroupId = groupId,
            };

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
                    string c = respond.Content.ReadAsStringAsync().Result;
                    groupId = JsonConvert.DeserializeObject<int>(c);
                }
            }

            return RedirectToAction($"EditGroup", "EditGroup", new { userId = userId, groupId = groupId });
        }

    }
}
