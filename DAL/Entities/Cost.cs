﻿using System;
using System.ComponentModel.DataAnnotations;
using DAL.Extras;

namespace DAL.Entities
{
    public class Cost : BaseEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }

        public int Price { get; set; }

        public CostType CostType { get; set; }

        public DateTime Date { get; set; }

        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
