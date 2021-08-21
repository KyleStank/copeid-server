using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using CopeID.API.Responses;
using CopeID.API.Services;
using CopeID.API.QueryModels;
using CopeID.Core.Exceptions;
using CopeID.Models;
namespace CopeID.API.Controllers
{
    [ProducesErrorResponseType(typeof(ErrorResponse))]
    public abstract class BaseEntityController<TEntity, TQueryModel, TLogger, TService> : BaseApiController
        where TEntity : Entity
        where TQueryModel : EntityQueryModel<TEntity>
        where TLogger : ControllerBase
        where TService : IBaseEntityService<TEntity, TQueryModel>
    {
        protected readonly ILogger<TLogger> _logger;
        protected readonly TService _entityService;

        public BaseEntityController(ILogger<TLogger> logger, TService entityService)
        {
            _logger = logger;
            _entityService = entityService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Get([FromQuery] TQueryModel queryModel)
        {
            List<TEntity> entities = await _entityService.GetAll(queryModel);
            return Ok(entities);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Get(Guid id, [FromQuery] TQueryModel queryModel)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                TEntity entity = await _entityService.GetUntrackedAsync(id, queryModel);
                return Ok(entity);
            }
            catch (EntityNotFoundException<TEntity> notFoundException)
            {
                return CreateNotFoundResponse(notFoundException.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public virtual async Task<IActionResult> Create([FromBody] TEntity model, [FromQuery] TQueryModel queryModel)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                TEntity entity = await _entityService.Create(model, queryModel);
                return CreatedAtAction(nameof(Create), entity);
            }
            catch (EntityNotCreatedException<TEntity> notCreatedException)
            {
                return CreateBadRequestResponse(notCreatedException.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Update([FromBody] TEntity model, [FromQuery] TQueryModel queryModel)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                TEntity entity = await _entityService.Update(model, queryModel);
                return Ok(entity);
            }
            catch (EntityNotFoundException<TEntity> notFoundException)
            {
                return CreateNotFoundResponse(notFoundException.Message);
            }
            catch (EntityNotUpdatedException<TEntity> notUpdatedException)
            {
                return CreateBadRequestResponse(notUpdatedException.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                await _entityService.Delete(id);
                return CreateNoContentResponse();
            }
            catch (EntityNotFoundException<TEntity> notFoundException)
            {
                return CreateNotFoundResponse(notFoundException.Message);
            }
            catch (EntityNotDeletedException<TEntity> notDeletedException)
            {
                return CreateBadRequestResponse(notDeletedException.Message);
            }
        }
    }
}
