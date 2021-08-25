using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CopeID.API.BodyData;
using CopeID.API.Services;
using CopeID.Core.Exceptions;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilterController : BaseApiController
    {
        private readonly IFilterService _filterService;

        public FilterController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Filter([FromBody] FilterData filterData)
        {
            try
            {
                Specimen specimen = await _filterService.Filter(filterData);
                return Ok(specimen);
            }
            catch (EntityNotFoundException<Specimen> notFoundException)
            {
                return CreateNotFoundResponse(notFoundException.Message);
            }
        }
    }
}
