using System.Linq;

using CopeID.Models.Filters;

namespace CopeID.QueryModels.Filters
{
    public class FilterQueryModel : EntityQueryModel<Filter>
    {
        protected override IQueryable<Filter> GetCustomQuery(IQueryable<Filter> query)
        {
            return query;
        }
    }
}
