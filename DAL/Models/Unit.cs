using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Unit : BaseEntity
    {
        public int? CurrentCapacity { get; set; }
        public int? MaxCapacity { get; set; }

        public int UnitTypeId { get; set; }

        [ForeignKey(nameof(UnitTypeId))]
        public virtual UnitType UnitType { get; set; }

        public int SpecificationId { get; set; }

        [ForeignKey(nameof(SpecificationId))]
        public virtual Specification Specification { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection<Equipment> AvailableEquipment { get; set; }

        public int UnitGroupId { get; set; }

        [ForeignKey(nameof(UnitGroupId))]
        public virtual UnitGroup UnitGroup { get; set; }

#nullable enable
        public string? ContractLink { get; set; }
    }
}