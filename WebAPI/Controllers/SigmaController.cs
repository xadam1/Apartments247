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

        public SigmaController(IUnitGroupFacade unitGroupFacade, IUnitFacade unitFacade)
        {
            //con = new ApartmentsDbContext();
            _unitGroupFacade = unitGroupFacade;
            _unitFacade = unitFacade;
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
        public async Task<UnitGroupNameModel[]> GetUnitGroupNamesByUserId(int userId)
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
        public UnitWithSpecificationModel[] GetUnitsByGroupId(int groupId)
        {
            /*Unit[] units = con.Units.Where(unit => unit.UnitGroupId == groupId).ToArray();
            return units.Select(unit => Utils.Convert(unit)).ToArray();*/
            return new UnitWithSpecificationModel[] { };
        }

        [HttpGet]
        [Route("GetUnitGroupById")]
        public ActionResult<UnitGroupWithSpecificationModel> GetUnitGroupById(int groupId)
        {
            /*UnitGroup group = con.UnitGroups.Where(group => group.Id == groupId).FirstOrDefault();
            if (group == null)
            {
                return BadRequest();
            }
            return Utils.Convert(group);*/
            return Ok();
        }

        [HttpGet]
        [Route("GetUnitById")]
        public ActionResult<UnitWithSpecificationModel> GetUnitById(int unitId)
        {
            /*Unit unit = con.Units.Where(unit => unit.Id == unitId).FirstOrDefault();
            if (unit == null)
            {
                return BadRequest();
            }
            return Utils.Convert(unit);*/
            return Ok();
        }

        [HttpGet]
        [Route("GetColors")]
        public Color[] GetColors()
        {
            /*Color[] colors = con.Colors.ToArray();
            return colors;*/
            return new Color[] { };
        }

        [HttpGet]
        [Route("GetUnitTypes")]
        public UnitTypeModel[] GetUnitTypes()
        {
            /*UnitType[] unitTypes = con.UnitTypes.ToArray();
            return unitTypes.Select(unitType => Utils.Convert(unitType)).ToArray();*/
            return new UnitTypeModel[] { };
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
