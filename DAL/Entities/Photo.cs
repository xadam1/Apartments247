using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Photo : BaseEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Path { get; set; }

        public DateTime DateTimeUploaded { get; set; }

        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }


#nullable enable
        [MaxLength(256)]
        public string? Description { get; set; }
    }
}