using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApartmentsDAL.Extras;

namespace ApartmentsDAL.Models
{
    public class Specification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public Color Color { get; set; }

        [MaxLength(1024)]
        public string Note { get; set; }

        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }
    }
}