using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentsDAL.Models
{
    public class UnitGroup
    {
        [Key]
        public int Id { get; set; }

        public int SpecificationId { get; set; }

        [ForeignKey(nameof(SpecificationId))]
        public Specification Specification { get; set; }
        
        public ICollection<Unit> Units { get; set; }
    }
}