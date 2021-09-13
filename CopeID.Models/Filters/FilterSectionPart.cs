using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopeID.Models.Filters
{
    public class FilterSectionPart : Entity
    {
        [Required]
        public Guid FilterSectionId { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public virtual FilterSection FilterSection { get; set; }

        public virtual ICollection<FilterSectionPartOption> FilterSectionPartOptions { get; set; }
    }
}
