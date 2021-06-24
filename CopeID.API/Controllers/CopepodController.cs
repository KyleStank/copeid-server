using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Models;
using CopeID.API.Services;

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
        public IActionResult GetAllCopepods()
        {
            List<Copepod> models = _copepodService.GetAllCopepods().ToList();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCopepod(Guid id)
        {
            Copepod copepod = await _copepodService.GetCopepod(id);
            if (copepod == null)
            {
                return BadRequest("Invalid Copepod ID provided.");
            }

            return Ok(copepod);
        }
    }
}
