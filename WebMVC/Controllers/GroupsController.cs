using DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using BLL.Facades;
using BLL.DTOs;
using WebAPI.Models;
using WebMVC.Models;
using WebMVC.Utils;

namespace WebMVC.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IUnitGroupFacade _unitGroupFacade;
        
        public GroupsController(IUnitGroupFacade unitGroupFacade)
        {
            this._unitGroupFacade = unitGroupFacade;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> MyGroups(int groupId)
        {
            Log.Called(nameof(MyGroups), $"GID [{groupId}]");

            GroupsOverviewDTO groups = new GroupsOverviewDTO()
            {
                UserId = UserInfoManager.UserId,
                UnitGroups = 
                    await _unitGroupFacade.GetUnitGroupsByUserIdAsync<UnitGroupNameUnitsDTO>(UserInfoManager.UserId)
            };
            
            return View(groups);
        }

        [HttpGet]
        public IActionResult CreateGroup()
        {
            Log.Called(nameof(CreateGroup), UserInfoManager.UserId.ToString());
            
            return null;
        }
        
        [HttpGet]
        public IActionResult EditGroup(int groupId, int createNewInt)
        {
            bool createNew = createNewInt > 0;

            EditGroupModel m = new EditGroupModel()
            {
                UserId = UserInfoManager.UserId,
                GroupId = groupId,
                CreateNew = createNew,
                Colors = Utils.Utils.GetColors(),
            };

            if (createNew || groupId == -1)
            {
                m.Group = new UnitGroupWithSpecificationModel()
                {
                    Id = -1,
                    UserId = UserInfoManager.UserId,
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
                m.Group = Utils.Utils.GetUnitGroupById(groupId);
            }

            return View(m);
        }

        [HttpPost]
        public IActionResult SaveGroup(int groupId, string name, int colorSelect,
            string note, string state, string city, string street, string number, string zip)
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

                string commandUrl = $"SaveUnitGroup?userId={UserInfoManager.UserId}&groupId={groupId}&name={name}&colorId={colorSelect}&note={note}" +
                                    $"&state={state}&city={city}&street={street}&number={number}&zip={zip}";
                using (HttpResponseMessage respond = client.GetAsync(ConnectionStrings.API_URL + commandUrl).Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    groupId = JsonConvert.DeserializeObject<int>(content);
                }
            }

            return RedirectToAction("MyGroups", "Groups", new { groupId = groupId });
        }

        [HttpGet]
        public IActionResult DeleteGroup(int groupId)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(ConnectionStrings.API_URL + $"DeleteGroup?groupId={groupId}").Result)
                {
                    // Nothing to do
                }
            }

            groupId = Utils.Utils.GetFirstUnitGroupIdByUserId();

            return RedirectToAction("MyGroups", "Groups", new { groupId = groupId });
        }
    }
}
