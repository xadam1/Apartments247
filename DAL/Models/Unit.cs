﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Unit : BaseEntity
    {
        public int MaxCapacity { get; set; }

        public int CurrentCapacity { get; set; }

        public int UnitTypeId { get; set; }

        [ForeignKey(nameof(UnitTypeId))]
        public virtual UnitType Type { get; set; }

        public int SpecificationId { get; set; }

        [ForeignKey(nameof(SpecificationId))]
        public virtual Specification Specification { get; set; }
    }
}