using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    // EQ TYPE
    public class EquipmentTypeDTO
    {
        [StringLength(64)]
        public string Type { get; set; }
    }
}