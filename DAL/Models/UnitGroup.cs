using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class UnitGroup : BaseEntity
    {
        // FK
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }

        // Collections
        public virtual ICollection<Unit> Units { get; set; }
    }
}