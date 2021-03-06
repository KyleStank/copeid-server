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
        public Guid?[] FilterModelPropertyId { get; set; } = null;

        [FromQuery]
        public int[] Order { get; set; } = null;

        [FromQuery]
        public string[] DisplayName { get; set; } = null;

        protected override IQueryable<FilterSectionPart> GetCustomQuery(IQueryable<FilterSectionPart> query)
        {
            if (FilterSectionId != null) query = query.Where(e => FilterSectionId.Contains(e.FilterSectionId));
            if (FilterModelPropertyId != null) query = query.Where(e => FilterModelPropertyId.Contains(e.FilterModelPropertyId));
            if (Order != null) query = query.Where(e => Order.Contains(e.Order));
            if (DisplayName != null) query = query.Where(e => DisplayName.Contains(e.DisplayName));

            return query;
        }
    }
}
