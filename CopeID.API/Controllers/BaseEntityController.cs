using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services;
using CopeID.Core.Exceptions;
using CopeID.Extensions;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    public abstract class BaseEntityController<TEntity, TLogger, TService> : BaseApiController
        where TEntity : Entity
        where TLogger : ControllerBase
        where TService : IBaseEntityService<TEntity>
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
        public virtual IActionResult GetAllEntites([FromQuery] string[] include)
        {
            List<TEntity> entities = _entityService.GetAllEntities(include?.ToPascalCase()).ToList();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetEntity(Guid id, [FromQuery] string[] include)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                TEntity entity = await _entityService.GetEntityUntrackedAsync(id, include?.ToPascalCase());
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

        public virtual async Task<IActionResult> CreateEntity([FromBody] TEntity model)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                TEntity entity = await _entityService.CreateEntity(model);
                return CreatedAtAction(nameof(CreateEntity), entity);
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
        public virtual async Task<IActionResult> UpdateEntity([FromBody] TEntity model)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                TEntity entity = await _entityService.UpdateEntity(model);
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
        public virtual async Task<IActionResult> DeleteEntity(Guid id)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                TEntity entity = await _entityService.DeleteEntity(id);
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
