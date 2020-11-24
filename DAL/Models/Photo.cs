using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Photo : BaseEntity
    {
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(512)]
        public string Path { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public DateTime DateTimeUploaded { get; set; }
    }
}