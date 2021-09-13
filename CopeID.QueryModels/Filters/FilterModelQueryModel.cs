using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Filters;

namespace CopeID.QueryModels.Filters
{
    public class FilterModelQueryModel : EntityQueryModel<FilterModel>
    {
        [FromQuery]
        public string[] TypeName { get; set; } = null;

        protected override IQueryable<FilterModel> GetCustomQuery(IQueryable<FilterModel> query)
        {
            if (TypeName != null) query = query.Where(e => TypeName.Contains(e.TypeName));

            return query;
        }
    }
}
