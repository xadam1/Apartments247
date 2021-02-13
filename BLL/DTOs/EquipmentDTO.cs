using DAL.Models;
using System.Collections.Generic;

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