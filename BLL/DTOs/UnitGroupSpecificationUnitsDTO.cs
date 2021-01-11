using DAL.Models;
using System.Collections.Generic;

namespace BLL.DTOs
{
    public class UnitGroupSpecificationUnitsDTO
    {
        public Specification Specification { get; set; }

        public ICollection<Unit> Units { get; set; }
    }
}
