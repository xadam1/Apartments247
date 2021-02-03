using BLL.DTOs;
using BLL.Facades;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAppMVC.Models;
using WebAppMVC.Utils;


namespace WebAppMVC.Controllers
{
    public class UnitsController : Controller
    {
        private readonly IUnitGroupFacade _ugFacade;
        private readonly IUnitFacade _unitFacade;

        public UnitsController(IUnitGroupFacade ugFacade, IUnitFacade unitFacade)
        {
            this._ugFacade = ugFacade;
            this._unitFacade = unitFacade;
        }

        [HttpGet]
        public async Task<IActionResult> MyUnits(int unitGroupID)
        {
            Log.Called(nameof(MyUnits), $"groupID={unitGroupID}");

            var units = new List<UnitFullDTO>();
            var currentGroup = new UnitGroupNameDto();
            var groups = await _ugFacade.GetUnitGroupsByUserIdAsync<UnitGroupNameDto>(UserInfoManager.UserId);
            
            if (unitGroupID != 0)
            {
                currentGroup = await _ugFacade.GetUnitGroupByIdAsync<UnitGroupNameDto>(unitGroupID);
                units = await _unitFacade.GetUnitsByGroupIdAsync<UnitFullDTO>(unitGroupID);
            }
            else
            {
                // User did not select UG, but has some
                if (groups.Any())
                {
                    currentGroup = groups.First();
                    units = await _unitFacade.GetUnitsByGroupIdAsync<UnitFullDTO>(currentGroup.Id);
                }
            }

            var dto = new UnitsOverviewDTO
            {
                UserId = UserInfoManager.UserId,
                Groups = groups,
                CurrentGroup = currentGroup,
                UnitsInGroup = units
            };

            Log.Info($"DTO: UID={dto.UserId}, curr_group={currentGroup.Name}, units={units.Count}");

            return View(dto);
        }

        public IActionResult CreateUnit()
        {
            Log.Called(nameof(CreateUnit));
            return View();
        }

        [HttpGet]
        public IActionResult EditUnit(int groupId, int unitId = -1)
        {
            Log.Called(nameof(EditUnit), $"groupID={groupId}, unitID={unitId}");

            EditUnitModel m = new EditUnitModel()
            {
                UserId = UserInfoManager.UserId,
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
                    ContractName = "nezadáno",
                };
            }
            else
            {
                m.Unit = Utils.Utils.GetUnitById(unitId);
            }

            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUnit(int unitId, int groupId, string name, int selectColor, string note,
            int selectUnitType, int currentCapacity, int maxCapacity, string contractLink, string state, string city,
            string street, string number, string zip, IFormFile file)
        {
            UnitDTO unit = await _unitFacade.GetUnitByIdAsync<UnitDTO>(unitId);
            var contract = GetContract(file, unit);

            if (unit == null)
            {
                Address address = new Address()
                {
                    State = state ?? string.Empty,
                    City = city != null ? state : string.Empty,
                    Street = street != null ? state : string.Empty,
                    Number = number != null ? state : string.Empty,
                    Zip = zip != null ? state : string.Empty,
                };

                Specification spec = new Specification()
                {
                    Name = name ?? string.Empty,
                    ColorId = selectColor,
                    Address = address,
                    Note = note ?? string.Empty,
                };

                unit = new UnitDTO()
                {
                    Specification = spec,
                    UnitGroupId = groupId,
                    UnitTypeId = selectUnitType,
                    CurrentCapacity = currentCapacity,
                    MaxCapacity = maxCapacity,
                    //ContractLink = contractLink ?? string.Empty,
                    Contract = contract
                };

                await _unitFacade.CreateUnitAsync(unit);
            }
            else
            {
                unit.Specification.Name = name ?? string.Empty;
                unit.Specification.ColorId = selectColor;
                unit.Specification.Note = note ?? string.Empty;

                unit.Specification.Address.State = state ?? string.Empty;
                unit.Specification.Address.City = city ?? string.Empty;
                unit.Specification.Address.Street = street ?? string.Empty;
                unit.Specification.Address.Number = number ?? string.Empty;
                unit.Specification.Address.Zip = zip ?? string.Empty;

                unit.UnitTypeId = selectUnitType;
                unit.UnitGroupId = groupId;
                unit.CurrentCapacity = currentCapacity;
                unit.MaxCapacity = maxCapacity;
                //unit.ContractLink = contractLink ?? string.Empty;
                unit.Contract = contract;
                unit.Contract.Name = contract.Name;
                unit.Contract.Content = contract.Content;

                await _unitFacade.UpdateUnitAsync(unitId, unit);
            }

            return RedirectToAction("MyUnits", "Units", new { groupId = groupId, unitId = unitId });
        }

        [HttpGet]
        public IActionResult DeleteUnit(int groupId, int unitId)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(ConnectionStrings.API_URL + $"DeleteUnit?unitId={unitId}").Result)
            {
                // Nothing to do
            }

            return RedirectToAction("MyUnits", "Units", new { groupId = groupId });
        }

        public async Task<FileResult> OpenContract(int id)
        {
            var unit = await _unitFacade.GetUnitByIdAsync<UnitDTO>(id);
            var fileBytes = unit?.Contract.Content ?? new byte[] { };

            /*var contract = 
            try
            {
                fileBytes = System.IO.File.ReadAllBytes(link);
            }
            catch (Exception)
            {
            }*/

            return File(fileBytes, "application/pdf");
        }

        private Contract GetContract(IFormFile file, UnitDTO unit)
        {
            var contract = new Contract();

            if (file == null)
            {
                return unit?.Contract ?? contract;
            }

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    contract.Content = memoryStream.ToArray();
                    contract.Name = file.FileName;
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            return contract;
        }
    }
}
