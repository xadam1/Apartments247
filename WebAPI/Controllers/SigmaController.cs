﻿using DAL;
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
        public int SaveUnitGroup(int userId, int groupId, string name, int colorId, string note)
        {
            UnitGroup group = con.UnitGroups.Where(group => group.Id == groupId).FirstOrDefault();

            if (group == null)
            {
                Specification spec = new Specification()
                {
                    Name = name,
                    ColorId = colorId,
                    Note = note,
                    AddressId = -1, // TODO
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
                group.Specification.Name = name;
                group.Specification.ColorId = colorId;
                group.Specification.Note = note;

                con.UnitGroups.Update(group);
            }
            con.SaveChanges();

            return group.Id;
        }

        [HttpGet]
        [Route("SaveUnit")]
        public int SaveUnit(int groupId, int unitId, string name, int colorId, string note, int unitTypeId, int currentCapacity, int maxCapacity, string contractLink)
        {
            Unit unit = con.Units.Where(unit => unit.Id == unitId).FirstOrDefault();

            if (unit == null)
            {
                Specification spec = new Specification()
                {
                    Name = name,
                    ColorId = colorId,
                    AddressId = -1, // TODO
                    Note = note,
                };

                unit = new Unit()
                {
                    Specification = spec,
                    UnitGroupId = groupId,
                    UnitTypeId = unitTypeId,
                    CurrentCapacity = currentCapacity,
                    MaxCapacity = maxCapacity,
                    ContractLink = contractLink,
                };

                con.Units.Add(unit);
            }
            else
            {
                unit.Specification.Name = name;
                unit.Specification.ColorId = colorId;
                unit.Specification.Note = note;
                unit.UnitTypeId = unitTypeId;
                unit.CurrentCapacity = currentCapacity;
                unit.MaxCapacity = maxCapacity;
                unit.ContractLink = contractLink;

                con.Units.Update(unit);
            }

            con.SaveChanges();

            return unit.Id;
        }
    }
}
