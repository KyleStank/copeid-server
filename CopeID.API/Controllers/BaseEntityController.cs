using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services;
using CopeID.Core.Exceptions;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    public abstract class BaseEntityController<TEntity, TService> : BaseApiController
        where TEntity : Entity
        where TService : IBaseEntityService<TEntity>
    {
        protected readonly TService _entityService;

        public BaseEntityController(TService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Get()
        {
            List<TEntity> entities = await _entityService.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                TEntity entity = await _entityService.GetUntrackedAsync(id);
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

        public virtual async Task<IActionResult> Create([FromBody] TEntity model)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                TEntity entity = await _entityService.Create(model);
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
        public virtual async Task<IActionResult> Update([FromBody] TEntity model)
        {
            if (!ModelState.IsValid) return CreateBadRequestResponse("Invalid body provided");

            try
            {
                TEntity entity = await _entityService.Update(model);
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
                //return CreateNoContentResponse(); // TODO: This returns an error in the client. Investigate BaseApiController to find the root.
                return NoContent();
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
