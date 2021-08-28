using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : BaseEntityController<Filter, IFilterService>
    {
        public FilterController(IFilterService filterService) : base(filterService)
        { }
    }
}
