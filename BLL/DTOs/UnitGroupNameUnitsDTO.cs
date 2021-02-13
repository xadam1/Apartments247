using System.Collections.Generic;
using DAL.Entities;

namespace BLL.DTOs
{
    public class UnitGroupNameUnitsDTO
    {
        public int Id { get; set; }
        
        public Specification Specification { get; set; }

        public string Name => Specification?.Name;
        
        public IEnumerable<UnitShowDTO> Units { get; set; }
    }
}