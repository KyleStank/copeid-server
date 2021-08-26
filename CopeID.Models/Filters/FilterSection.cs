﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopeID.Models.Filters
{
    public class FilterSection : Entity
    {
        [Required]
        public Guid FilterId { get; set; }

        [Required]
        public string Code { get; set; } // L

        [Required]
        public string DisplayName { get; set; } // Length of Specimen (mm)

        public virtual Filter Filter { get; set; }

        public virtual ICollection<FilterSectionOption> Options { get; set; } // (0.5, Z), (1, Y), (1.5, X), (2, W)
    }
}