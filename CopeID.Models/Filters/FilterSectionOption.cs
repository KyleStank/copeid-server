using System;
using System.ComponentModel.DataAnnotations;

namespace CopeID.Models.Filters
{
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
