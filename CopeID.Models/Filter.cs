using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopeID.Models
{
    public class Filter : Entity
    {
        [Required]
        public string EntityType { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public virtual ICollection<FilterSection> Sections { get; set; }
    }

    public class FilterSection : Entity
    {
        [Required]
        public Guid FilterId { get; set; }

        [Required]
        public string EntityProperty { get; set; }

        [Required]
        public FilterSectionEntityPropertyType EntityPropertyType { get; set; }

        [Required]
        public string Code { get; set; } // L

        [Required]
        public string DisplayName { get; set; } // Length of Specimen (mm)

        public virtual Filter Filter { get; set; }

        public virtual ICollection<FilterSectionOption> Options { get; set; } // (0.5, Z), (1, Y), (1.5, X), (2, W)
    }

    public enum FilterSectionEntityPropertyType
    {
        String = 0,
        Boolean = 1,
        Integer = 2,
        Decimal = 3
    }

    public class FilterSectionOption : Entity
    {
        [Required]
        public Guid FilterSectionId { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Value { get; set; } // 0.5

        public virtual FilterSection Section { get; set; }
    }
}