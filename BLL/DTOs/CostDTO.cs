using DAL.Extras;
using DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class CostDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public CostType CostType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
