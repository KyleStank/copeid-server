using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services;
using CopeID.API.QueryModels;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenusController : BaseEntityController<Genus, GenusQueryModel, GenusController, IGenusService>
    {
        public GenusController(ILogger<GenusController> logger, IGenusService genusService) : base(logger, genusService) { }
    }
}
