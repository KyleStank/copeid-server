using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services.References;
using CopeID.API.QueryModels.References;
using CopeID.Models.References;

namespace CopeID.API.Controllers.References
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceController : BaseEntityController<Reference, ReferenceQueryModel, ReferenceController, IReferenceService>
    {
        public ReferenceController(ILogger<ReferenceController> logger, IReferenceService referenceService) : base(logger, referenceService) { }
    }
}
