﻿using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace BLL.DTOs
{
    public class SpecificationNameNoteAddressDTO
    {
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Note { get; set; }

        public Address Address { get; set; }
    }
}