using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Filters;

namespace CopeID.QueryModels.Filters
{
    public class FilterSectionPartOptionQueryModel : EntityQueryModel<FilterSectionPartOption>
    {
        [FromQuery]
        public Guid[] FilterSectionPartId { get; set; } = null;

        [FromQuery]
        public string[] DisplayName { get; set; } = null;

        [FromQuery]
        public string[] Code { get; set; } = null;

        [FromQuery]
        public string[] Value { get; set; } = null;

        protected override IQueryable<FilterSectionPartOption> GetCustomQuery(IQueryable<FilterSectionPartOption> query)
        {
            if (FilterSectionPartId != null) query = query.Where(e => FilterSectionPartId.Contains(e.FilterSectionPartId));
            if (DisplayName != null) query = query.Where(e => DisplayName.Contains(e.DisplayName));
            if (Code != null) query = query.Where(e => Code.Contains(e.Code));
            if (Value != null) query = query.Where(e => Value.Contains(e.Value));

            return query;
        }
    }
}
