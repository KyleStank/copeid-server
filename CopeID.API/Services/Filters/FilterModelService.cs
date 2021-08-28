using CopeID.Context;
using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterModelService : BaseEntityService<FilterModel>, IFilterModelService
    {
        public FilterModelService(CopeIdDbContext context) : base(context)
        { }
    }
}
