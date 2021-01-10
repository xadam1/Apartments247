using System.Collections.Generic;

namespace DAL.Models
{
    public class Unit : BaseEntity
    {
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
        public virtual ICollection<MonthlyCost> Costs { get; set; }

#nullable enable
        public string? ContractLink { get; set; }
    }
}