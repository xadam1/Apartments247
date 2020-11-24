using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class UnitGroup : BaseEntity
    {
        public int SpecificationId { get; set; }
        
        [ForeignKey(nameof(SpecificationId))]
        public virtual Specification Specification { get; set; }
        
        public virtual ICollection<Unit> Units { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}