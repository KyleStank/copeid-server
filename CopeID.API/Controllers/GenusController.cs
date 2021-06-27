using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using CopeID.API.Models;
using CopeID.API.Services;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenusController : BaseCRUDController<Genus, GenusController, IGenusService>
    {
        public GenusController(ILogger<GenusController> logger, IGenusService genusService) : base(logger, genusService) { }
    }

    //[ApiController]
    //[Route("[controller]")]
    //public class GenusController : ControllerBase, ICrudController<Genus>
    //{
    //    private readonly ILogger<GenusController> _logger;
    //    private readonly IGenusService _genusService;

    //    public GenusController(ILogger<GenusController> logger, IGenusService genusService)
    //    {
    //        _logger = logger;
    //        _genusService = genusService;
    //    }

    //    //public IActionResult GetAllEntities()
    //    //{
    //    //    return null;
    //    //}

    //    [HttpGet("{id}")]
    //    [ProducesResponseType(StatusCodes.Status200OK)]
    //    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    //    public async Task<IActionResult> GetEntity(Guid id)
    //    {
    //        //return Ok(await _genusService.GetGenus(id));

    //        Genus entity = await _genusService.GetGenus(id);
    //        if (entity == null)
    //        {
    //            return BadRequest("Invalid ID provided.");
    //        }

    //        return Ok(entity);
    //    }

    //    //public Task<IActionResult> CreateEntity(Genus model)
    //    //{
    //    //    return null;
    //    //}

    //    //public Task<IActionResult> UpdateEntity(Genus model)
    //    //{
    //    //    return null;
    //    //}

    //    //public Task<IActionResult> DeleteEntity(Guid id)
    //    //{
    //    //    return null;
    //    //}
    //}
}
