using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class User : BaseEntity
    {
        public virtual ICollection<UnitGroup> UnitGroups { get; set; }

        [Required]
        [MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

#nullable enable
        [Required]
        [EmailAddress]
        [MaxLength(128)]
        public string? Email { get; set; }
    }
}
