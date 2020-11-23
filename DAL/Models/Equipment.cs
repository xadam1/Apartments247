﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Equipment : BaseEntity
    {
        public int UnitId { get; set; }

        [ForeignKey(nameof(UnitId))]
        public virtual Unit Unit { get; set; }

        public virtual ICollection<EquipmentType> AvailableEquipment { get; set; }
    }
}