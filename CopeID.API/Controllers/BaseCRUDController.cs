using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using CopeID.API.Extensions;
using CopeID.API.Models;
using CopeID.API.Services;

namespace CopeID.API.Controllers
{
    public abstract class BaseCRUDController<TEntity, TLogger, TService> : ControllerBase
        where TEntity : Entity
        where TLogger : ControllerBase
        where TService : IBaseCRUDService<TEntity>
    {
        protected readonly ILogger<TLogger> _logger;
        protected readonly TService _entityService;

        public BaseCRUDController(ILogger<TLogger> logger, TService entityService)
        {
            _logger = logger;
            _entityService = entityService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual IActionResult GetAllEntites([FromQuery] string[] include)
        {
            List<TEntity> entities = _entityService.GetAllEntities(include?.ToPaselCase()).ToList();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> GetEntity(Guid id, [FromQuery] string[] include)
        {
            TEntity entity = await _entityService.GetEntityUntrackedAsync(id, include?.ToPaselCase());
            if (entity == null)
            {
                return BadRequest("Invalid Entity ID provided.");
            }

            return Ok(entity);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public virtual async Task<IActionResult> CreateEntity([FromBody] TEntity model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Entity model provided.");
            }

            TEntity entity = await _entityService.CreateEntity(model);
            if (entity == null)
            {
                return BadRequest("Unable to create Entity.");
            }

            return CreatedAtAction(nameof(CreateEntity), entity);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> UpdateEntity([FromBody] TEntity model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Entity model provided.");
            }

            TEntity entity = await _entityService.UpdateEntity(model);
            if (entity == null)
            {
                return BadRequest("Unable to update Entity.");
            }

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> DeleteEntity(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Entity model provided.");
            }

            TEntity entity = await _entityService.DeleteEntity(id);
            if (entity == null)
            {
                return BadRequest("Unable to delete Entity.");
            }

            return NoContent();
        }
    }
}
