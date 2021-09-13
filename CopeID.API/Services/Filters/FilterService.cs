using CopeID.Context;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterService : BaseQueryableEntityService<Filter, FilterQueryModel>, IFilterService
    {
        public FilterService(CopeIdDbContext context) : base(context)
        { }
    }
}
