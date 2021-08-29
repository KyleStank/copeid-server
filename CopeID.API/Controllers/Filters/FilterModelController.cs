using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CopeID.API.Services.Filters;
using CopeID.Models.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterModelController : BaseEntityController<FilterModel, IFilterModelService>
    {
        public FilterModelController(IFilterModelService filterModelService) : base(filterModelService)
        { }

        [HttpGet("Types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult GetTypes()
        {
            return Ok(_entityService.GetEntityTypes().Select(t => t.FullName));
        }
    }
}
