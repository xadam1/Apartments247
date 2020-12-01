using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Equipment : BaseEntity
    {
        public virtual ICollection<Unit> Units { get; set; }

        [MaxLength(64)]
        public string Type { get; set; }
    }
}