using BLL.DTOs;
using BLL.Facades;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Models;
using WebMVC.Models;
using WebMVC.Utils;

namespace WebMVC.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IColorFacade _colorFacade;
        private readonly IUnitGroupFacade _unitGroupFacade;

        public GroupsController(IUnitGroupFacade unitGroupFacade, IColorFacade colorFacade)
        {
            _unitGroupFacade = unitGroupFacade;
            _colorFacade = colorFacade;
        }


        [HttpGet]
        public async Task<IActionResult> MyGroups(int groupId)
        {
            Log.Called(nameof(MyGroups), $"GID [{groupId}]");

            var groups = new GroupsOverviewDTO
            {
                UserId = UserInfoManager.UserId,
                UnitGroups =
                    await _unitGroupFacade.GetUnitGroupsByUserIdAsync<UnitGroupNameUnitsDTO>(UserInfoManager.UserId)
            };

            return View(groups);
        }

        [HttpGet]
        public async Task<IActionResult> CreateGroup()
        {
            Log.Called(nameof(CreateGroup), UserInfoManager.UserId.ToString());

            var dto = new CreateGroupDTO
            {
                Colors = await _colorFacade.GetColorsAsync<ColorDTO>()
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(string name, int colorId, string street, string streetNumber,
            string city, string zip, string state, string noteText)
        {
            var address = new Address
            {
                State = state ?? string.Empty,
                City = city ?? string.Empty,
                Street = street ?? string.Empty,
                Number = streetNumber ?? string.Empty,
                Zip = zip ?? string.Empty
            };

            var spec = new Specification
            {
                Name = name ?? string.Empty,
                Note = noteText ?? string.Empty,
                ColorId = colorId,
                Address = address
            };

            var unitGroup = new UnitGroupDTO
            {
                UserId = UserInfoManager.UserId,
                Specification = spec
            };

            await _unitGroupFacade.CreateUnitGroupAsync(unitGroup);
            return RedirectToAction("MyGroups");
        }


        [HttpGet]
        public IActionResult EditGroup(int groupId, int createNewInt)
        {
            var createNew = createNewInt > 0;

            var m = new EditGroupModel
            {
                UserId = UserInfoManager.UserId,
                GroupId = groupId,
                CreateNew = createNew,
                Colors = Utils.Utils.GetColors()
            };

            if (createNew || groupId == -1)
                m.Group = new UnitGroupWithSpecificationModel
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
                    Zip = "zip"
                };
            else
                m.Group = Utils.Utils.GetUnitGroupById(groupId);

            return View(m);
        }

        [HttpPost]
        public IActionResult SaveGroup(int groupId, string name, int colorSelect,
            string note, string state, string city, string street, string number, string zip)
        {
            using (var client = new HttpClient())
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

                var commandUrl =
                    $"SaveUnitGroup?userId={UserInfoManager.UserId}&groupId={groupId}&name={name}&colorId={colorSelect}&note={note}" +
                    $"&state={state}&city={city}&street={street}&number={number}&zip={zip}";
                using (var respond = client.GetAsync(ConnectionStrings.API_URL + commandUrl).Result)
                {
                    var content = respond.Content.ReadAsStringAsync().Result;
                    groupId = JsonConvert.DeserializeObject<int>(content);
                }
            }

            return RedirectToAction("MyGroups", "Groups", new { groupId });
        }

        [HttpGet]
        public IActionResult DeleteGroup(int groupId)
        {
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(ConnectionStrings.API_URL + $"DeleteGroup?groupId={groupId}")
                    .Result)
                {
                    // Nothing to do
                }
            }

            groupId = Utils.Utils.GetFirstUnitGroupIdByUserId();

            return RedirectToAction("MyGroups", "Groups", new { groupId });
        }
    }
}