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
            return groups.Select(Utils.Convert).ToArray();
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
                                                                   .Select(Utils.Convert).ToArray();

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

            return unitTypesDTOs.Select(Utils.Convert).ToArray();
        }


        [HttpGet]
        [Route("SaveUnitGroup")]
        public async Task<int> SaveUnitGroupAsync(int userId, int groupId, string name, int colorId, string note, string state,
            string city, string street, string number, string zip)
        {
            UnitGroupDTO group = await _unitGroupFacade.GetUnitGroupByIdAsync<UnitGroupDTO>(groupId);

            if (group == null)
            {
                Address address = new Address()
                {
                    State = state ?? string.Empty,
                    City = city ?? string.Empty,
                    Street = street ?? string.Empty,
                    Number = number ?? string.Empty,
                    Zip = zip ?? string.Empty,
                };

                Specification spec = new Specification()
                {
                    Name = name ?? string.Empty,
                    ColorId = colorId,
                    Note = note ?? string.Empty,
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
                group.Specification.Name = name ?? string.Empty;
                group.Specification.ColorId = colorId;
                group.Specification.Note = note ?? string.Empty;

                group.Specification.Address.State = state ?? string.Empty;
                group.Specification.Address.City = city ?? string.Empty;
                group.Specification.Address.Street = street ?? string.Empty;
                group.Specification.Address.Number = number ?? string.Empty;
                group.Specification.Address.Zip = zip ?? string.Empty;

                await _unitGroupFacade.UpdateUnitGroupAsync(groupId, group);
            }

            return group.Id;
        }


        [HttpGet]
        [Route("SaveUnit")]
        public async Task<int> SaveUnitAsync(int groupId, int unitId, string name, int colorId, string note, int unitTypeId,
            int currentCapacity, int maxCapacity, string contractLink, string state, string city, string street, string number, string zip)
        {
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

                unit = new UnitDTO()
                {
                    Specification = spec,
                    UnitGroupId = groupId,
                    UnitTypeId = unitTypeId,
                    CurrentCapacity = currentCapacity,
                    MaxCapacity = maxCapacity,
                    ContractLink = contractLink ?? string.Empty,
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
                unit.ContractLink = contractLink ?? string.Empty;

                await _unitFacade.UpdateUnitAsync(unitId, unit);
            }

            return unit.Id;
        }

        [HttpGet]
        [Route("DeleteGroup")]
        public void DeleteGroup(int groupId)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            UnitGroup unitGroup = con.UnitGroups.FirstOrDefault(unitGroup => unitGroup.Id == groupId);
            con.UnitGroups.Remove(unitGroup);
            con.SaveChanges();
        }

        [HttpGet]
        [Route("DeleteUnit")]
        public void DeleteUnit(int unitId)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            Unit unit = con.Units.FirstOrDefault(unit => unit.Id == unitId);
            con.Units.Remove(unit);
            con.SaveChanges();
        }

        [HttpGet]
        [Route("GetFirstUnitGroupIdByUserId")]
        public ActionResult<int> GetFirstUnitGroupIdByUserId(int userId)
        {
            ApartmentsDbContext con = new ApartmentsDbContext();
            UnitGroup unitGroup = con.UnitGroups.FirstOrDefault(unitGroup => unitGroup.UserId == userId);
            if (unitGroup == null)
            {
                return NotFound();
            }
            return unitGroup.Id;
        }
    }
}
