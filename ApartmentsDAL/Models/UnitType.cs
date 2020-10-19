using System.ComponentModel.DataAnnotations;

namespace ApartmentsDAL.Models
{
    public class UnitType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Type { get; set; }
    }
}