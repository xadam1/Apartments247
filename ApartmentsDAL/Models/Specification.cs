using System.ComponentModel.DataAnnotations;
using ApartmentsDAL.Extras;

namespace ApartmentsDAL.Models
{
    public class Specification
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        public Color Color { get; set; }

        [MaxLength(1024)]
        public string Note { get; set; }

        public Address Address { get; set; }
    }
}