using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Definitions;
using CopeID.Models.Definitions;
using CopeID.QueryModels.Definitions;

namespace CopeID.API.Controllers.Definitions
{
    [ApiController]
    [Route("[controller]")]
    public class DefinitionController : BaseEntityQueryableController<Definition, DefinitionQueryModel, IDefinitionService>
    {
        public DefinitionController(IDefinitionService definitionService) : base(definitionService)
        { }
    }
}
