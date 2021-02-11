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

        public int MonthlyIncome { get; set; }

        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }

        // Collections
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<UnitEquipment> UnitEquipments { get; set; }
        public virtual ICollection<Cost> Costs { get; set; }
    }
}
