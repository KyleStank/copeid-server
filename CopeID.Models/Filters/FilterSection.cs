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

        public string Code { get; set; }

        public string DisplayName { get; set; }

        public virtual Filter Filter { get; set; }

        public virtual FilterModelProperty FilterModelProperty { get; set; }

        public virtual ICollection<FilterSectionPart> FilterSectionParts { get; set; }
    }
}
