using System.Collections.Generic;

namespace DAL.Entities
{
    public class UnitGroup : BaseEntity
    {
        public int OwnerId { get; set; }

        // FK
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }

        // Collections
        public virtual ICollection<Unit> Units { get; set; }
    }
}