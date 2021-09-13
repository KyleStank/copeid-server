using CopeID.Context;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterModelPropertyService : BaseQueryableEntityService<FilterModelProperty, FilterModelPropertyQueryModel>, IFilterModelPropertyService
    {
        public FilterModelPropertyService(CopeIdDbContext context) : base(context)
        { }
    }
}
