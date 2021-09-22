using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Filters;

namespace CopeID.QueryModels.Filters
{
    public class FilterQueryModel : EntityQueryModel<Filter>
    {
        [FromQuery]
        public Guid[] FilterModelId { get; set; } = null;

        [FromQuery]
        public string[] DisplayName { get; set; } = null;

        protected override IQueryable<Filter> GetCustomQuery(IQueryable<Filter> query)
        {
            if (FilterModelId != null) query = query.Where(e => FilterModelId.Contains(e.FilterModelId));
            if (DisplayName != null) query = query.Where(e => DisplayName.Contains(e.DisplayName));

            return query;
        }
    }
}
