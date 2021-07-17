using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefinitionController : BaseEntityController<Definition, DefinitionController, IDefinitionService>
    {
        public DefinitionController(ILogger<DefinitionController> logger, IDefinitionService definitionService)
            : base(logger, definitionService) { }
    }
}
