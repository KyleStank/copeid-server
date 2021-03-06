using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services;
using CopeID.API.ViewModels.Pagination;
using CopeID.Core.Exceptions;
using CopeID.Models;
using CopeID.QueryModels;

namespace CopeID.API.Controllers
{
    public abstract class BaseEntityQueryableController<TEntity, TQueryModel, TService> : BaseApiController
        where TEntity : Entity
        where TQueryModel : EntityQueryModel<TEntity>
        where TService : IBaseQueryableEntityService<TEntity, TQueryModel>
    {
        protected readonly TService _entityService;

        public BaseEntityQueryableController(TService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Get([FromQuery] TQueryModel queryModel, [FromQuery] PaginationRequest paginationRequest)
        {
            // If a pagination request was supplied, use pagination and limit the number of returned results.
            if (paginationRequest.IsValid())
            {
                PaginationResponse<TEntity> paginationResponse = await _entityService.GetPaged(
                    new PaginationRequest(paginationRequest.PageNumber, paginationRequest.PageSize),
                    queryModel
                );
                return Ok(paginationResponse);
            }

            // Otherwise, return everything.
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
