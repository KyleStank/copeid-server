using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Filters;

namespace CopeID.QueryModels.Filters
{
    public class FilterModelPropertyQueryModel : EntityQueryModel<FilterModelProperty>
    {
        [FromQuery]
        public Guid[] FilterModelId { get; set; } = null;

        [FromQuery]
        public string[] PropertyName { get; set; } = null;

        protected override IQueryable<FilterModelProperty> GetCustomQuery(IQueryable<FilterModelProperty> query)
        {
            if (FilterModelId != null) query = query.Where(e => FilterModelId.Contains(e.FilterModelId));
            if (PropertyName != null) query = query.Where(e => PropertyName.Contains(e.PropertyName));

            return query;
        }
    }
}
