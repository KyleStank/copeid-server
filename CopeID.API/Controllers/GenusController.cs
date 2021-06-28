using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Models;
using CopeID.API.Services;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenusController : BaseCrudController<Genus, GenusController, IGenusService>
    {
        public GenusController(ILogger<GenusController> logger, IGenusService genusService) : base(logger, genusService) { }
    }
}
