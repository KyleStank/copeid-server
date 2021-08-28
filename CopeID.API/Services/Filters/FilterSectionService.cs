using CopeID.Context;
using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterSectionService : BaseEntityService<FilterSection>, IFilterSectionService
    {
        public FilterSectionService(CopeIdDbContext context) : base(context)
        { }
    }
}
