using System.Collections.Generic;

namespace BLL.DTOs
{
    public class GroupsOverviewDTO
    {
        public int UserId { get; set; }

        public IEnumerable<UnitGroupNameUnitsDTO> UnitGroups { get; set; }
    }
}