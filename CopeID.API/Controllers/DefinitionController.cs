using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services;
using CopeID.API.QueryModels;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefinitionController : BaseEntityController<Definition, DefinitionQueryModel, DefinitionController, IDefinitionService>
    {
        public DefinitionController(ILogger<DefinitionController> logger, IDefinitionService definitionService)
            : base(logger, definitionService) { }
    }
}
