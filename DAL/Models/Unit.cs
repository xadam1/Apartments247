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

        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }

        // Collections
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<UnitEquipment> UnitEquipments { get; set; }
        public virtual ICollection<MonthlyCost> MonthlyCosts { get; set; }
    }
}