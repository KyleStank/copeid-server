using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Controllers.Filters
{
    // TODO: Re-enable primary Filter entity controller once proper Filter DB design has been decided.
    //[ApiController]
    //[Route("[controller]")]
    //public class FilterController : BaseEntityController<Filter, FilterQueryModel, FilterController, IFilterService>
    //{
    //    public FilterController(ILogger<FilterController> logger, IFilterService filterService)
    //        : base(logger, filterService) { }
    //}

    [ApiController]
    [Route("[controller]")]
    public class FilterController : BaseApiController
    {
        private readonly ILogger<FilterController> _logger;
        private readonly IFilterService _filterService;

        public FilterController(ILogger<FilterController> logger, IFilterService filterService)
        {
            _logger = logger;
            _filterService = filterService;
        }
    }
}
