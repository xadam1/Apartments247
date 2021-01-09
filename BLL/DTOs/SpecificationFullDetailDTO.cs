﻿using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    // SPEC
    public class SpecificationFullDetailDTO
    {
        [StringLength(128)]
        public string Name { get; set; }

        public Color Color { get; set; }

        [StringLength(1024)]
        public string Note { get; set; }

        public Address Address { get; set; }
    }
}