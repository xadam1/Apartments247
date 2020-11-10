using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class UnitGroup
    {
        [Key]
        public int Id { get; set; }

        public int SpecificationId { get; set; }

        [ForeignKey(nameof(SpecificationId))]
        public virtual Specification Specification { get; set; }
        
        public virtual ICollection<Unit> Units { get; set; }
    }
}