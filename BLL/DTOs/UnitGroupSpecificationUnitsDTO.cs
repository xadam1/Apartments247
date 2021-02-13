using System.Collections.Generic;
using DAL.Entities;

namespace BLL.DTOs
{
    public class UnitGroupSpecificationUnitsDTO
    {
        public Specification Specification { get; set; }

        public ICollection<Unit> Units { get; set; }
    }
}
