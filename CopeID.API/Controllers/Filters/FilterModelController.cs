using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services.Filters;
using CopeID.Core.Exceptions;
using CopeID.Models.Filters;
using CopeID.QueryModels.Filters;

namespace CopeID.API.Controllers.Filters
{
    [ApiController]
    [Route("[controller]")]
    public class FilterModelController : BaseApiController
    {
        private readonly ILogger<FilterModelController> _logger;
        private readonly IFilterModelService _filterModelService;

        public FilterModelController(ILogger<FilterModelController> logger, IFilterModelService filterModelService)
        {
            _logger = logger;
            _filterModelService = filterModelService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Get()
        {
            List<FilterModel> filterModels = await _filterModelService.GetAll();
            return Ok(filterModels);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Create([FromBody] FilterModel model)
        {
            try
            {
                FilterModel filterModel = await _filterModelService.Create(model);
                return Ok(filterModel);
            }
            catch (EntityNotCreatedException<FilterModel> notCreatedException)
            {
                return CreateBadRequestResponse(notCreatedException.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Update([FromBody] FilterModel model)
        {
            try
            {
                FilterModel filterModel = await _filterModelService.Update(model);
                return Ok(filterModel);
            }
            catch (EntityNotFoundException<FilterModel> notFoundException)
            {
                return CreateNotFoundResponse(notFoundException.Message);
            }
            catch (EntityNotUpdatedException<FilterModel> notUpdatedException)
            {
                return CreateBadRequestResponse(notUpdatedException.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _filterModelService.Delete(id);
                return NoContent();
            }
            catch (EntityNotFoundException<FilterModel> notFoundException)
            {
                return CreateNotFoundResponse(notFoundException.Message);
            }
            catch (EntityNotDeletedException<FilterModel> notDeletedException)
            {
                return CreateBadRequestResponse(notDeletedException.Message);
            }
        }
    }
}
