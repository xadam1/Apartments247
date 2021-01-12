using Microsoft.AspNetCore.Mvc;
using MVC.Controllers;
using MVC.Models;
using Newtonsoft.Json;
using System.Net.Http;
using WebAPI.Models;

namespace WebAppMVC.Controllers
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
                Colors = Utils.GetColors(),
            };

            if (createNew || groupId == -1)
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
                m.Group = Utils.GetUnitGroupById(groupId);
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
            }

            groupId = Utils.GetFirstUnitGroupIdByUserId(userId);

            return RedirectToAction("ListGroups", "ListGroups", new { userId = userId, groupId = groupId });
        }
    }
}
