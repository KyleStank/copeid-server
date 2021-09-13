using System;
using System.ComponentModel.DataAnnotations;

namespace CopeID.Models.Filters
{
    public class FilterSectionPartOption : Entity
    {
        [Required]
        public Guid FilterSectionPartId { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Value { get; set; }

        public virtual FilterSectionPart FilterSectionPart { get; set; }
    }
}
