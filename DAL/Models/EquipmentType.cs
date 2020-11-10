using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class EquipmentType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Type { get; set; }
    }
}