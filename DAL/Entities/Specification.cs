﻿using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Specification : BaseEntity
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public int ColorId { get; set; }
        public virtual Color Color { get; set; }


        public int AddressId { get; set; }
        public virtual Address Address { get; set; }


#nullable enable
        [MaxLength(1024)]
        public string? Note { get; set; }
    }
}