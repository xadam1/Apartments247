using System.Collections.Generic;

namespace BLL.DTOs
{
    public class CreateUnitDTO
    {
        public UnitFullDTO Unit { get; set; }

        public UnitGroupNameDTO SelectedUnitGroup { get; set; }
        
        public IEnumerable<UnitGroupNameDTO> UnitGroups { get; set; }

        public IEnumerable<UnitTypeDTO> UnitTypes { get; set; }

        public IEnumerable<ColorDTO> Colors { get; set; }
    }
}