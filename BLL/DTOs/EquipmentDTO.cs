using System.Collections.Generic;
using DAL.Entities;

namespace BLL.DTOs
{
    public class EquipmentDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<UnitEquipment> UnitEquipments { get; set; }
    }
}