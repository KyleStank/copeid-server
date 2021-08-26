using System.Linq;

using CopeID.Models;

namespace CopeID.API.QueryModels
{
    public class FilterQueryModel : EntityQueryModel<Filter>
    {
        protected override IQueryable<Filter> GetCustomQuery(IQueryable<Filter> query)
        {
            return query;
        }
    }
}
