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
}
