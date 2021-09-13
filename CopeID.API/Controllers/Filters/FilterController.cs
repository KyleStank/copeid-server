using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : BaseEntityQueryableController<Filter, FilterQueryModel, IFilterService>
    {
        public FilterController(IFilterService filterService) : base(filterService)
        { }
    }
}
