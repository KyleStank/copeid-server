using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CopeID.API.Services.Filters;
using CopeID.API.ViewModels.Filters;
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

        [HttpGet("Specimen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async virtual Task<IActionResult> GetSpecimenFilter()
        {
            Filter specimenFilter = await _entityService.GetSpecimenFilter();
            return Ok(specimenFilter);
        }

        [HttpPost("Result")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async virtual Task<IActionResult> GetFilterResult([FromBody] FilterResultRequestViewModel resultRequest)
        {
            var result = await _entityService.FilterResults(resultRequest);
            return Ok(result);
        }
    }
}
