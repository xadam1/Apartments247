using System.Collections.Generic;
using DAL.Models;

namespace BLL.DTOs
{
    public class GroupsOverviewDTO
    {
        public int UserId { get; set; }

        public IEnumerable<UnitGroupNameUnitsDTO> UnitGroups { get; set; }
    }
}