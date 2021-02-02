using System.Collections.Generic;

namespace BLL.DTOs
{
    public class UnitsOverviewDTO
    {
        public int UserId { get; set; }

        public IEnumerable<UnitGroupNameDto> Groups { get; set; }

        public UnitGroupNameDto CurrentGroup { get; set; }

        public IEnumerable<UnitFullDTO> UnitsInGroup { get; set; }
    }
}