using CopeID.Context;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterSectionOptionService : BaseQueryableEntityService<FilterSectionOption, FilterSectionOptionQueryModel>, IFilterSectionOptionService
    {
        public FilterSectionOptionService(CopeIdDbContext context) : base(context)
        { }
    }
}
