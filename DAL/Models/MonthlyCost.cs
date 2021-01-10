﻿using DAL.Extras;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class MonthlyCost : BaseEntity
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