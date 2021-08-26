using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopeID.Models.Filters
{
    public class FilterModel : Entity
    {
        [Required]
        public string TypeName { get; set; }

        public virtual ICollection<FilterModelProperty> TypeProperties { get; set; }

        public virtual ICollection<Filter> Filters { get; set; }
    }

    public class FilterModelProperty : Entity
    {
        [Required]
        public Guid FilterModelId { get; set; }

        [Required]
        public string PropertyName { get; set; }
    }

    public class Filter : Entity
    {
        [Required]
        public Guid FilterModelId { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public virtual FilterModel Model { get; set; }

        public virtual ICollection<FilterSection> Sections { get; set; }
    }

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