using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CopeID.API.Services.Filters;
using CopeID.Core.Exceptions;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterSectionController : BaseEntityQueryableController<FilterSection, FilterSectionQueryModel, IFilterSectionService>
    {
        public FilterSectionController(IFilterSectionService filterSectionService) : base(filterSectionService)
        { }

        [HttpGet("{id}/Options")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetOptions(Guid id)
        {
            try
            {
                IEnumerable<FilterSectionOption> options = await _entityService.GetOptions(id);
                return Ok(options);
            }
            catch (EntityNotFoundException<FilterSectionOption> notFoundException)
            {
                return CreateNotFoundResponse(notFoundException.Message);
            }
        }
    }
}
