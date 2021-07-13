using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenusController : BaseEntityController<Genus, GenusController, IGenusService>
    {
        public GenusController(ILogger<GenusController> logger, IGenusService genusService) : base(logger, genusService) { }
    }
}
