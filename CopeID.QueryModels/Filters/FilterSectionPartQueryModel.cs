using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Filters;

namespace CopeID.QueryModels.Filters
{
    public class FilterSectionPartQueryModel : EntityQueryModel<FilterSectionPart>
    {
        [FromQuery]
        public Guid[] FilterSectionId { get; set; } = null;

        [FromQuery]
        public string[] DisplayName { get; set; } = null;

        protected override IQueryable<FilterSectionPart> GetCustomQuery(IQueryable<FilterSectionPart> query)
        {
            if (FilterSectionId != null) query = query.Where(e => FilterSectionId.Contains(e.FilterSectionId));
            if (DisplayName != null) query = query.Where(e => DisplayName.Contains(e.DisplayName));

            return query;
        }
    }
}
