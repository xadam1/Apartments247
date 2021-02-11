using System.Collections.Generic;

namespace BLL.DTOs
{
    public class UnitsOverviewDTO
    {
        public int UserId { get; set; }

        public IEnumerable<UnitGroupNameDTO> Groups { get; set; }

        public UnitGroupNameDTO CurrentGroup { get; set; }

        public IEnumerable<UnitFullDTO> UnitsInGroup { get; set; }
    }
}