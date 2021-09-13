using CopeID.Context;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterSectionPartService : BaseQueryableEntityService<FilterSectionPart, FilterSectionPartQueryModel>, IFilterSectionPartService
    {
        public FilterSectionPartService(CopeIdDbContext context) : base(context)
        { }
    }
}
