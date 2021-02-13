using System.Collections.Generic;
using DAL.Entities;

namespace BLL.DTOs
{
    public class EquipmentDTO
    {
        public string Type { get; set; }

        public virtual ICollection<UnitEquipment> UnitEquipments { get; set; }

        public int CurrentUnitEquipmentId { get; set; }
        public virtual UnitEquipment CurrentUnitEquipment { get; set; }
    }
}