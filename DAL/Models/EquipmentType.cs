using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class EquipmentType : BaseEntity
    {
        [MaxLength(64)]
        public string Type { get; set; }
    }
}