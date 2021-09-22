using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopeID.Models.Filters
{
    public class FilterSection : Entity
    {
        [Required]
        public Guid FilterId { get; set; }

        [Required]
        public int Order { get; set; }

        public string Code { get; set; }

        public string DisplayName { get; set; }

        public virtual Filter Filter { get; set; }

        public virtual ICollection<FilterSectionPart> FilterSectionParts { get; set; }
    }
}
