using System.Collections.Generic;

namespace BLL.DTOs
{
    public class EquipmentsWithUnitIdDTO
    {
        public IEnumerable<EquipmentDTO> EquipmentsDTO { get; set; }

        public int UnitId { get; set; }
    }
}