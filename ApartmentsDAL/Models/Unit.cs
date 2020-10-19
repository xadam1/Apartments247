using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentsDAL.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        public int MaxCapacity { get; set; }

        public int CurrentCapacity { get; set; }

        public int UnitTypeId { get; set; }

        [ForeignKey(nameof(UnitTypeId))]
        public UnitType Type { get; set; }

        public int SpecificationId { get; set; }

        [ForeignKey(nameof(SpecificationId))]
        public Specification Specification { get; set; }
    }
}