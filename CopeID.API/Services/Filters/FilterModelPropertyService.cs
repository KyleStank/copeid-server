using CopeID.Context;
using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterModelPropertyService : BaseEntityService<FilterModelProperty>, IFilterModelPropertyService
    {
        public FilterModelPropertyService(CopeIdDbContext context) : base(context)
        { }
    }
}
