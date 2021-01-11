using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Address : BaseEntity
    {
        [Required]
        [MaxLength(64)]
        public string Street { get; set; }

        [Required]
        [MaxLength(64)]
        public string Number { get; set; }

#nullable enable
        [MaxLength(64)]
        public string? Zip { get; set; }

        [MaxLength(64)]
        public string? State { get; set; }

        [MaxLength(64)]
        public string? City { get; set; }
    }
}