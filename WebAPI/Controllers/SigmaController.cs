using BLL.DTOs;
using BLL.Facades;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Extras;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SigmaController : Controller
    {
        private readonly IUnitGroupFacade _unitGroupFacade;
        private readonly IUnitFacade _unitFacade;
        private readonly IColorFacade _colorFacade;
        private readonly IUnitTypeFacade _unitTypeFacade;

        public SigmaController(IUnitGroupFacade unitGroupFacade, IUnitFacade unitFacade, IColorFacade colorFacade, IUnitTypeFacade unitTypeFacade)
        {
            _unitGroupFacade = unitGroupFacade;
            _unitFacade = unitFacade;
            _colorFacade = colorFacade;
            _unitTypeFacade = unitTypeFacade;
        }

        [HttpGet]
        [Route("GetUnitGroupsByUserId")]
        public async Task<UnitGroupWithSpecificationModel[]> GetUnitGroupsByUserIdAsync(int userId)
        {
            UnitGroupDTO[] groups = await _unitGroupFacade.GetUnitGroupsByUserIdAsync<UnitGroupDTO>(userId);
            return groups.Select(group => Utils.Convert(group)).ToArray();
        }

        [HttpGet]
        [Route("GetUnitGroupNamesByUserId")]
        public async Task<UnitGroupNameModel[]> GetUnitGroupNamesByUserIdAsync(int userId)
        {
            UnitGroupNameModel[] groups = (await _unitGroupFacade.GetUnitGroupNamesByUserId<UnitGroupDTO>(userId))
                                           .Select(group => new UnitGroupNameModel(group.Id, group.Specification.Name)).ToArray();
            return groups;
        }

        [HttpGet]
        [Route("GetUnitsByUnitGroupId")]
        public async Task<UnitWithSpecificationModel[]> GetUnitsByGroupIdAsync(int groupId)
        {
            UnitWithSpecificationModel[] units = (await _unitFacade.GetUnitsByGroupIdAsync<UnitDTO>(groupId))
                                                                   .Select(unit => Utils.Convert(unit)).ToArray();

            return units;
        }

        [HttpGet]
        [Route("GetUnitGroupById")]
        public async Task<ActionResult<UnitGroupWithSpecificationModel>> GetUnitGroupByIdAsync(int groupId)
        {
            UnitGroupDTO group = await _unitGroupFacade.GetUnitGroupByIdAsync<UnitGroupDTO>(groupId);
            if (group == null)
            {
                return BadRequest();
            }

            return Utils.Convert(group);
        }

        [HttpGet]
        [Route("GetUnitById")]
        public async Task<ActionResult<UnitWithSpecificationModel>> GetUnitById(int unitId)
        {
            UnitDTO unit = await _unitFacade.GetUnitByIdAsync<UnitDTO>(unitId);
            if (unit == null)
            {
                return BadRequest();
            }

            return Utils.Convert(unit);
        }

        [HttpGet]
        [Route("GetColors")]
        public async Task<ColorDTO[]> GetColors()
        {
            return await _colorFacade.GetColorsAsync<ColorDTO>();
        }

        [HttpGet]
        [Route("GetUnitTypes")]
        public async Task<UnitTypeModel[]> GetUnitTypes()
        {
            var unitTypesDTOs = await _unitTypeFacade.GetUnitTypesAsync<UnitTypeDTO>();

            return unitTypesDTOs.Select(unitType => Utils.Convert(unitType)).ToArray();
        }


        [HttpGet]
        [Route("SaveUnitGroup")]
        public async Task<int> SaveUnitGroupAsync(int userId, int groupId, string name, int colorId, string note, string state, string city, string street, string number, string zip)
        {
            UnitGroupDTO group = await _unitGroupFacade.GetUnitGroupByIdAsync<UnitGroupDTO>(groupId);

            if (group == null)
            {
                Address address = new Address()
                {
                    State = state != null ? state : string.Empty,
                    City = city != null ? city : string.Empty,
                    Street = street != null ? street : string.Empty,
                    Number = number != null ? number : string.Empty,
                    Zip = zip != null ? zip : string.Empty,
                };

                Specification spec = new Specification()
                {
                    Name = name != null ? name : string.Empty,
                    ColorId = colorId,
                    Note = note != null ? note : string.Empty,
                    Address = address,
                };

                group = new UnitGroupDTO()
                {
                    UserId = userId,
                    Specification = spec,
                };

                await _unitGroupFacade.CreateUnitGroupAsync(group);
            }
            else
            {
                group.Specification.Name = name != null ? name : string.Empty;
                group.Specification.ColorId = colorId;
                group.Specification.Note = note != null ? note : string.Empty;

                group.Specification.Address.State = state != null ? state : string.Empty;
                group.Specification.Address.City = city != null ? city : string.Empty;
                group.Specification.Address.Street = street != null ? street : string.Empty;
                group.Specification.Address.Number = number != null ? number : string.Empty;
                group.Specification.Address.Zip = zip != null ? zip : string.Empty;

                await _unitGroupFacade.UpdateUnitGroupAsync(groupId, group);
            }

            return group.Id;
        }


        [HttpGet]
        [Route("SaveUnit")]
        public async Task<int> SaveUnitAsync(int groupId, int unitId, string name, int colorId, string note, int unitTypeId, int currentCapacity, int maxCapacity, string contractLink, string state, string city, string street, string number, string zip)
        {
            UnitDTO unit = await _unitFacade.GetUnitByIdAsync<UnitDTO>(unitId);
            if (unit == null)
            {
                Address address = new Address()
                {
                    State = state != null ? state : string.Empty,
                    City = city != null ? state : string.Empty,
                    Street = street != null ? state : string.Empty,
                    Number = number != null ? state : string.Empty,
                    Zip = zip != null ? state : string.Empty,
                };

                Specification spec = new Specification()
                {
                    Name = name != null ? name : string.Empty,
                    ColorId = colorId,
                    Address = address,
                    Note = note != null ? note : string.Empty,
                };

                unit = new UnitDTO()
                {
                    Specification = spec,
                    UnitGroupId = groupId,
                    UnitTypeId = unitTypeId,
                    CurrentCapacity = currentCapacity,
                    MaxCapacity = maxCapacity,
                    ContractLink = contractLink != null ? contractLink : string.Empty,
                };
                
                await _unitFacade.CreateUnitAsync(unit);
            }
            else
            {
                unit.Specification.Name = name != null ? name : string.Empty;
                unit.Specification.ColorId = colorId;
                unit.Specification.Note = note != null ? note : string.Empty;

                unit.Specification.Address.State = state != null ? state : string.Empty;
                unit.Specification.Address.City = city != null ? city : string.Empty;
                unit.Specification.Address.Street = street != null ? street : string.Empty;
                unit.Specification.Address.Number = number != null ? number : string.Empty;
                unit.Specification.Address.Zip = zip != null ? zip : string.Empty;

                unit.UnitTypeId = unitTypeId;
                unit.UnitGroupId = groupId;
                unit.CurrentCapacity = currentCapacity;
                unit.MaxCapacity = maxCapacity;
                unit.ContractLink = contractLink != null ? contractLink : string.Empty;

                await _unitFacade.UpdateUnitAsync(unitId, unit);
            }

            return unit.Id;
        }

        [HttpGet]
        [Route("DeleteGroup")]
        public void DeleteGroup(int groupId)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            UnitGroup unitGroup = con.UnitGroups.Where(unitGroup => unitGroup.Id == groupId).FirstOrDefault();
            con.UnitGroups.Remove(unitGroup);
            con.SaveChanges();
        }

        [HttpGet]
        [Route("DeleteUnit")]
        public void DeleteUnit(int unitId)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            Unit unit = con.Units.Where(unit => unit.Id == unitId).FirstOrDefault();
            con.Units.Remove(unit);
            con.SaveChanges();
        }

        [HttpGet]
        [Route("GetFirstUnitGroupIdByUserId")]
        public ActionResult<int> GetFirstUnitGroupIdByUserId(int userId)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            UnitGroup unitGroup = con.UnitGroups.Where(unitGroup => unitGroup.UserId == userId).FirstOrDefault();
            if (unitGroup == null)
            {
                return NotFound();
            }
            return unitGroup.Id;
        }
    }
}
