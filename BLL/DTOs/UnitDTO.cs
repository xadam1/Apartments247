using DAL.Models;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class UnitDTO
    {
        public int Id { get; set; }

        public int? CurrentCapacity { get; set; }
        public int? MaxCapacity { get; set; }

        // FK
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }

        public int UnitTypeId { get; set; }
        public virtual UnitType UnitType { get; set; }

        public int UnitGroupId { get; set; }
        public virtual UnitGroup UnitGroup { get; set; }

        // Collections
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Equipment> AvailableEquipment { get; set; }
        //public virtual ICollection<MonthlyCost> MonthlyCosts { get; set; }    // TODO Vojta

#nullable enable
        public string? ContractLink { get; set; }
    }
}
