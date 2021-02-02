using BLL.DTOs;
using BLL.Facades;
using DAL;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAppMVC.Models;
using WebAppMVC.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using DAL.Models;
using BLL.DTOs;

namespace WebAppMVC.Controllers
{
    public class UnitsController : Controller
    {
        private readonly ILog log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            log.Info($"Called: MyUnits({unitGroupID})");

            var units = new List<UnitFullDTO>();
            var currentGroup = new UnitGroupNameDto();

            if (unitGroupID != 0)
            {
                currentGroup = await _ugFacade.GetUnitGroupByIdAsync<UnitGroupNameDto>(unitGroupID);
                units = await _unitFacade.GetUnitsByGroupIdAsync<UnitFullDTO>(unitGroupID);
            }

            var dto = new UnitsOverviewDTO
            {
                UserId = UserInfoManager.UserId,
                Groups = await _ugFacade.GetUnitGroupsByUserIdAsync<UnitGroupNameDto>(UserInfoManager.UserId),
                CurrentGroup = currentGroup,
                UnitsInGroup = units
            };

            return View(dto);
        }

        public IActionResult CreateUnit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditUnit(int groupId, int unitId = -1)
        {
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
            string street, string number, string zip, IFormFile file)
        {
            var contract = CreateContract(file);
            var x = $"{contract.Content}";
            /*using (HttpClient client = new HttpClient())
            {
                
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
                
                string commandUrl = $"SaveUnit?groupId={groupId}&unitId={unitId}&name={name}&colorId={selectColor}&note={note}" +
                                    $"&unitTypeId={selectUnitType}&currentCapacity={currentCapacity}&maxCapacity={maxCapacity}" +
                                    $"&contractLink={contractLink}&state={state}&city={city}&street={street}&number={number}&zip={zip}";

                using (HttpResponseMessage respond = client.GetAsync(ConnectionStrings.API_URL + commandUrl).Result)
                {
                    string content = respond.Content.ReadAsStringAsync().Result;
                    unitId = JsonConvert.DeserializeObject<int>(content);
                }
            }*/

            UnitDTO unit = await _unitFacade.GetUnitByIdAsync<UnitDTO>(unitId);
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
                    ColorId = colorId,
                    Address = address,
                    Note = note ?? string.Empty,
                };

                var contract = new Contract(); // TODO

                unit = new UnitDTO()
                {
                    Specification = spec,
                    UnitGroupId = groupId,
                    UnitTypeId = unitTypeId,
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
                unit.Specification.ColorId = colorId;
                unit.Specification.Note = note ?? string.Empty;

                unit.Specification.Address.State = state ?? string.Empty;
                unit.Specification.Address.City = city ?? string.Empty;
                unit.Specification.Address.Street = street ?? string.Empty;
                unit.Specification.Address.Number = number ?? string.Empty;
                unit.Specification.Address.Zip = zip ?? string.Empty;

                unit.UnitTypeId = unitTypeId;
                unit.UnitGroupId = groupId;
                unit.CurrentCapacity = currentCapacity;
                unit.MaxCapacity = maxCapacity;
                //unit.ContractLink = contractLink ?? string.Empty;
                unit.Contract = new Contract();

                await _unitFacade.UpdateUnitAsync(unitId, unit);
            }

            return RedirectToAction("EditUnit", "Units", new { groupId = groupId, unitId = unitId });
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

        public FileResult OpenContract(string link)
        {
            byte[] fileBytes = { };
            try
            {
                fileBytes = System.IO.File.ReadAllBytes(link);
            }
            catch (Exception)
            {
            }

            return File(fileBytes, "application/pdf");
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var contract = new Contract()
                    {
                        Content = memoryStream.ToArray(),
                        Name = file.FileName
                    };

                    //_dbContext.File.Add(file);

                    //await _dbContext.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }

            //return Page();
            return View();
        }

        private Contract CreateContract(IFormFile file)
        {
            var contract = new Contract();

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    contract.Content = memoryStream.ToArray();
                    contract.Name = file.FileName;

                    //_dbContext.File.Add(file);

                    //await _dbContext.SaveChangesAsync();
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
