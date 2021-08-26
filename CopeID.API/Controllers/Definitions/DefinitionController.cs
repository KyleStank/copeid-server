using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services.Definitions;
using CopeID.Models.Definitions;
using CopeID.QueryModels.Definitions;

namespace CopeID.API.Controllers.Definitions
{
    [ApiController]
    [Route("[controller]")]
    public class DefinitionController : BaseEntityController<Definition, DefinitionQueryModel, DefinitionController, IDefinitionService>
    {
        public DefinitionController(ILogger<DefinitionController> logger, IDefinitionService definitionService)
            : base(logger, definitionService) { }
    }
}
