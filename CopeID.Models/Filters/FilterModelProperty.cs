using System;
using System.ComponentModel.DataAnnotations;

namespace CopeID.Models.Filters
{
    public class FilterModelProperty : Entity
    {
        [Required]
        public Guid FilterModelId { get; set; }

        [Required]
        public string PropertyName { get; set; }

        public virtual FilterModel FilterModel { get; set; }
    }
}
