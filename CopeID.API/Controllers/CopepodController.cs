using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Models;
using CopeID.API.Services;
using Microsoft.AspNetCore.Http;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CopepodController : ControllerBase
    {
        private readonly ILogger<CopepodController> _logger;
        private readonly ICopepodService _copepodService;

        public CopepodController(ILogger<CopepodController> logger, ICopepodService copepodService)
        {
            _logger = logger;
            _copepodService = copepodService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllCopepods()
        {
            List<Copepod> models = _copepodService.GetAllCopepods().ToList();
            return Ok(models);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCopepod(Guid id)
        {
            Copepod copepod = await _copepodService.GetUntrackedCopepod(id);
            if (copepod == null)
            {
                return BadRequest("Invalid Copepod ID provided.");
            }

            return Ok(copepod);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreateCopepod([FromBody] Copepod model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Copepod model provided.");
            }

            Copepod copepod = await _copepodService.CreateCopepod(model);
            if (copepod == null)
            {
                return BadRequest("Unable to create Copepod.");
            }

            return CreatedAtAction(nameof(CreateCopepod), copepod);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCopepod([FromBody] Copepod model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Copepod model provided.");
            }

            Copepod copepod = await _copepodService.UpdateCopeod(model);
            if (copepod == null)
            {
                return BadRequest("Unable to update Copepod.");
            }

            return Ok(copepod);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCopepod(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Copepod model provided.");
            }

            Copepod copeod = await _copepodService.DeleteCopepod(id);
            if (copeod == null)
            {
                return BadRequest("Unable to delete Copepod.");
            }

            return NoContent();
        }
    }
}
