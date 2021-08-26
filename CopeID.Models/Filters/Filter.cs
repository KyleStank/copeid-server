using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopeID.Models.Filters
{
    public class Filter : Entity
    {
        [Required]
        public Guid FilterModelId { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public virtual FilterModel Model { get; set; }

        public virtual ICollection<FilterSection> Sections { get; set; }
    }
}