using System.Collections.Generic;
using DAL.Entities;

namespace BLL.DTOs
{
    public class UnitGroupDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}
