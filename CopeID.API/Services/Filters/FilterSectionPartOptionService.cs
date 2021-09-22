using CopeID.Context;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterSectionPartOptionService : BaseQueryableEntityService<FilterSectionPartOption, FilterSectionPartOptionQueryModel>, IFilterSectionPartOptionService
    {
        public FilterSectionPartOptionService(CopeIdDbContext context) : base(context)
        { }
    }
}
