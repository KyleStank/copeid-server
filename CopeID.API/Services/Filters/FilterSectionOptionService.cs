using CopeID.Context;
using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterSectionOptionService : BaseEntityService<FilterSectionOption>, IFilterSectionOptionService
    {
        public FilterSectionOptionService(CopeIdDbContext context) : base(context)
        { }
    }
}
