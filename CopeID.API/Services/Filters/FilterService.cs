using CopeID.API.QueryModels.Filters;
using CopeID.Context;
using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterService : BaseEntityService<Filter, FilterQueryModel>, IFilterService
    {
        public FilterService(CopeIdDbContext context) : base(context) { }
    }
}
