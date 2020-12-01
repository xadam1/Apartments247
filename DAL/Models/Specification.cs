using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Extras;

namespace DAL.Models
{
    public class Specification : BaseEntity
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public Color? Color { get; set; }

        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }

#nullable enable
        [MaxLength(1024)]
        public string? Note { get; set; }
    }
}