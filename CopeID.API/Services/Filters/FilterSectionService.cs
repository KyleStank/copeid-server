using CopeID.Context;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterSectionService : BaseQueryableEntityService<FilterSection, FilterSectionQueryModel>, IFilterSectionService
    {
        public FilterSectionService(CopeIdDbContext context) : base(context)
        { }
    }
}
