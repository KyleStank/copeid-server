using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopeID.Models.Filters
{
    public class FilterSection : Entity
    {
        [Required]
        public Guid FilterId { get; set; }

        public Guid? FilterModelPropertyId { get; set; }

        public string Code { get; set; } // L

        public string DisplayName { get; set; } // Length of Specimen (mm)

        public virtual Filter Filter { get; set; }

        public virtual FilterModelProperty FilterModelProperty { get; set; }

        public virtual ICollection<FilterSectionOption> FilterSectionOptions { get; set; } // (0.5, Z), (1, Y), (1.5, X), (2, W)
    }
}
