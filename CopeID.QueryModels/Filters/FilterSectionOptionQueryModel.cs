using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Filters;

namespace CopeID.QueryModels.Filters
{
    public class FilterSectionOptionQueryModel : EntityQueryModel<FilterSectionOption>
    {
        [FromQuery]
        public Guid[] FilterSectionId { get; set; } = null;

        [FromQuery]
        public string[] DisplayName { get; set; } = null;

        [FromQuery]
        public string[] Value { get; set; } = null;

        protected override IQueryable<FilterSectionOption> GetCustomQuery(IQueryable<FilterSectionOption> query)
        {
            if (FilterSectionId != null) query = query.Where(e => FilterSectionId.Contains(e.FilterSectionId));
            if (DisplayName != null) query = query.Where(e => DisplayName.Contains(e.DisplayName));
            if (Value != null) query = query.Where(e => Value.Contains(e.Value));

            return query;
        }
    }
}
