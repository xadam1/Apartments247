using DAL.Extras;
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class MonthlyCost : BaseEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }

        public int Price { get; set; }

        public CostType CostType { get; set; }

        public DateTime Date { get; set; }
    }
}