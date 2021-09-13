using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Filters;

namespace CopeID.QueryModels.Filters
{
    public class FilterSectionQueryModel : EntityQueryModel<FilterSection>
    {
        [FromQuery]
        public Guid[] FilterId { get; set; } = null;

        [FromQuery]
        public Guid?[] FilterModelPropertyId { get; set; } = null;

        [FromQuery]
        public string[] Code { get; set; } = null;

        [FromQuery]
        public string[] DisplayName { get; set; } = null;

        protected override IQueryable<FilterSection> GetCustomQuery(IQueryable<FilterSection> query)
        {
            if (FilterId != null) query = query.Where(e => FilterId.Contains(e.FilterId));
            if (FilterModelPropertyId != null) query = query.Where(e => FilterModelPropertyId.Contains(e.FilterModelPropertyId));
            if (Code != null) query = query.Where(e => Code.Contains(e.Code));
            if (DisplayName != null) query = query.Where(e => DisplayName.Contains(e.DisplayName));

            return query;
        }
    }
}
