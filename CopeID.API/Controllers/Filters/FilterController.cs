using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : BaseEntityController<Filter, FilterQueryModel, FilterController, IFilterService>
    {
        public FilterController(ILogger<FilterController> logger, IFilterService filterService)
            : base(logger, filterService) { }
    }
}
