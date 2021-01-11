using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPI.Extras;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SigmaController : Controller
    {
        private readonly ApartmentsDbContext con;

        public SigmaController()
        {
            con = new ApartmentsDbContext();
        }

        [HttpGet]
        [Route("GetUnitGroupsByUserId")]
        public UnitGroupWithSpecificationModel[] GetUnitGroupsByUserId(int userId)
        {
            UnitGroup[] groups = con.UnitGroups.Where(group => group.UserId == userId).ToArray();
            return groups.Select(group => Utils.Convert(group)).ToArray();
        }

        [HttpGet]
        [Route("GetUnitGroupNamesByUserId")]
        public UnitGroupNameModel[] GetUnitGroupNamesByUserId(int userId)
        {
            UnitGroupNameModel[] groups = con.UnitGroups.Where(group => group.UserId == userId)
                .Select(group => new UnitGroupNameModel(group.Id, group.Specification.Name)).ToArray();
            return groups;
        }

        [HttpGet]
        [Route("GetUnitsByUnitGroupId")]
        public UnitWithSpecificationModel[] GetUnitsByGroupId(int groupId)
        {
            Unit[] units = con.Units.Where(unit => unit.UnitGroupId == groupId).ToArray();
            return units.Select(unit => Utils.Convert(unit)).ToArray();
        }

        [HttpGet]
        [Route("GetUnitGroupById")]
        public ActionResult<UnitGroupWithSpecificationModel> GetUnitGroupById(int groupId)
        {
            UnitGroup group = con.UnitGroups.Where(group => group.Id == groupId).FirstOrDefault();
            if (group == null)
            {
                return BadRequest();
            }
            return Utils.Convert(group);
        }

        [HttpGet]
        [Route("GetUnitById")]
        public ActionResult<UnitWithSpecificationModel> GetUnitById(int unitId)
        {
            Unit unit = con.Units.Where(unit => unit.Id == unitId).FirstOrDefault();
            if (unit == null)
            {
                return BadRequest();
            }
            return Utils.Convert(unit);
        }

        [HttpGet]
        [Route("GetColors")]
        public Color[] GetColors()
        {
            Color[] colors = con.Colors.ToArray();
            return colors;
        }

        [HttpGet]
        [Route("GetUnitTypes")]
        public UnitTypeModel[] GetUnitTypes()
        {
            UnitType[] unitTypes = con.UnitTypes.ToArray();
            return unitTypes.Select(unitType => Utils.Convert(unitType)).ToArray();
        }

        [HttpGet]
        [Route("SaveUnitGroup")]
        public int SaveUnitGroup(int userId, int groupId, string name, int colorId, string note, string state, string city, string street, string number, string zip)
        {
            UnitGroup group = con.UnitGroups.Where(group => group.Id == groupId).FirstOrDefault();

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
                
                group = new UnitGroup()
                {
                    UserId = userId,
                    Specification = spec,
                };

                con.UnitGroups.Add(group);
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

                con.UnitGroups.Update(group);
            }
            con.SaveChanges();

            return group.Id;
        }

        [HttpGet]
        [Route("SaveUnit")]
        public int SaveUnit(int groupId, int unitId, string name, int colorId, string note, int unitTypeId, int currentCapacity, int maxCapacity, string contractLink, string state, string city, string street, string number, string zip)
        {
            Unit unit = con.Units.Where(unit => unit.Id == unitId).FirstOrDefault();

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

                unit = new Unit()
                {
                    Specification = spec,
                    UnitGroupId = groupId,
                    UnitTypeId = unitTypeId,
                    CurrentCapacity = currentCapacity,
                    MaxCapacity = maxCapacity,
                    ContractLink = contractLink != null ? contractLink : string.Empty,
                };

                con.Units.Add(unit);
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

                con.Units.Update(unit);
            }

            con.SaveChanges();

            return unit.Id;
        }
    }
}
