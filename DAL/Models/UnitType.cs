﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class UnitType : BaseEntity
    {
        [MaxLength(64)]
        public string Type { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}