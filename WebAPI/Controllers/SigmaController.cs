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
    [Route("[controller]")]
    public class SigmaController : ControllerBase
    {
        //private readonly ApartmentsDbContext con;
        private readonly IUnitGroupFacade _unitGroupFacade;
        private readonly IUnitFacade _unitFacade;
        private readonly IColorFacade _colorFacade;
        private readonly IUnitTypeFacade _unitTypeFacade;

        public SigmaController(IUnitGroupFacade unitGroupFacade, IUnitFacade unitFacade, IColorFacade colorFacade, IUnitTypeFacade unitTypeFacade)
        {
            //con = new ApartmentsDbContext();
            _unitGroupFacade = unitGroupFacade;
            _unitFacade = unitFacade;
            _colorFacade = colorFacade;
            _unitTypeFacade = unitTypeFacade;
        }

        [HttpGet]
        [Route("GetUnitGroupsByUserId")]
        public async Task<UnitGroupWithSpecificationModel[]> GetUnitGroupsByUserIdAsync(int userId)
        {
            /*UnitGroup[] groups = con.UnitGroups.Where(group => group.UserId == userId).ToArray();
            return groups.Select(group => Utils.Convert(group)).ToArray();*/
            UnitGroupDTO[] groups = await _unitGroupFacade.GetUnitGroupsByUserIdAsync<UnitGroupDTO>(userId);
            return groups.Select(group => Utils.Convert(group)).ToArray();
        }

        [HttpGet]
        [Route("GetUnitGroupNamesByUserId")]
        public async Task<UnitGroupNameModel[]> GetUnitGroupNamesByUserIdAsync(int userId)
        {
            /*UnitGroupNameModel[] groups = con.UnitGroups.Where(group => group.UserId == userId)
                .Select(group => new UnitGroupNameModel(group.Id, group.Specification.Name)).ToArray();
            return groups;*/
            UnitGroupNameModel[] groups = (await _unitGroupFacade.GetUnitGroupNamesByUserId<UnitGroupDTO>(userId))
                                           .Select(group => new UnitGroupNameModel(group.Id, group.Specification.Name)).ToArray();
            return groups;
        }

        [HttpGet]
        [Route("GetUnitsByUnitGroupId")]
        public async Task<UnitWithSpecificationModel[]> GetUnitsByGroupIdAsync(int groupId)
        {
            /*Unit[] units = con.Units.Where(unit => unit.UnitGroupId == groupId).ToArray();
            return units.Select(unit => Utils.Convert(unit)).ToArray();*/

            UnitWithSpecificationModel[] units = (await _unitFacade.GetUnitsByGroupIdAsync<UnitDTO>(groupId))
                                                                   .Select(unit => Utils.Convert(unit)).ToArray();

            return units;
        }

        [HttpGet]
        [Route("GetUnitGroupById")]
        public async Task<ActionResult<UnitGroupWithSpecificationModel>> GetUnitGroupByIdAsync(int groupId)
        {
            /*UnitGroup group = con.UnitGroups.Where(group => group.Id == groupId).FirstOrDefault();
            if (group == null)
            {
                return BadRequest();
            }
            return Utils.Convert(group);*/

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
            /*Unit unit = con.Units.Where(unit => unit.Id == unitId).FirstOrDefault();
            if (unit == null)
            {
                return BadRequest();
            }
            return Utils.Convert(unit);*/

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
            /*Color[] colors = con.Colors.ToArray();
            return colors;*/

            return await _colorFacade.GetColorsAsync<ColorDTO>();
        }

        [HttpGet]
        [Route("GetUnitTypes")]
        public async Task<UnitTypeModel[]> GetUnitTypes()
        {
            /*UnitType[] unitTypes = con.UnitTypes.ToArray();
            return unitTypes.Select(unitType => Utils.Convert(unitType)).ToArray();*/

            var unitTypesDTOs = await _unitTypeFacade.GetUnitTypesAsync<UnitTypeDTO>();

            return unitTypesDTOs.Select(unitType => Utils.Convert(unitType)).ToArray();
        }

        [HttpGet]
        [Route("SaveUnitGroup")]
        public int SaveUnitGroup(int userId, int groupId, string name, int colorId, string note)
        {
            /*UnitGroup group = con.UnitGroups.Where(group => group.Id == groupId).FirstOrDefault();

            if (group == null)
            {
                Specification spec = new Specification()
                {
                    Name = name,
                    ColorId = colorId,
                    Note = note
                };

                group = new UnitGroup()
                {
                    Id = groupId,
                    UserId = userId,
                    Specification = spec
                };

                con.UnitGroups.Add(group);
            }
            else
            {
                group.Specification.Name = name;
                group.Specification.ColorId = colorId;
                group.Specification.Note = note;

                con.UnitGroups.Update(group);
            }
            con.SaveChanges();

            return group.Id;*/
            return 1;
        }

        // Save Unit
    }
}
