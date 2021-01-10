using BLL.DTOs;
using DAL.Models;
using WebAPI.Models;

namespace WebAPI.Extras
{
    public static class Utils
    {
        public static UnitGroupWithSpecificationModel Convert(UnitGroupDTO group)
        {
            return new UnitGroupWithSpecificationModel()
            {
                Id = group.Id,
                UserId = group.UserId,
                Name = group.Specification.Name,
                ColorId = group.Specification.ColorId,
                Color = group.Specification.Color.Name,
                AddressId = group.Specification.AddressId,
                Note = group.Specification.Note
            };
        }

        public static UnitWithSpecificationModel Convert(Unit unit)
        {
            return new UnitWithSpecificationModel()
            {
                Id = unit.Id,
                UnitGroupId = unit.UnitGroupId,
                CurrentCapacity = unit.CurrentCapacity.Value,
                MaxCapacity = unit.MaxCapacity.Value,
                Name = unit.Specification.Name,
                ColorId = unit.Specification.ColorId,
                Color = unit.Specification.Color.Name,
                AddressId = unit.Specification.AddressId,
                Note = unit.Specification.Note,
                UnitTypeId = unit.UnitTypeId,
                UnitType = unit.UnitType.Type,
                ContractLink = unit.ContractLink
            };
        }

        public static UnitTypeModel Convert(UnitType unitType)
        {
            return new UnitTypeModel()
            {
                Id = unitType.Id,
                Type = unitType.Type,
            };
        }
    }
}
