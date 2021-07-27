using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceController : BaseEntityController<Reference, ReferenceController, IReferenceService>
    {
        public ReferenceController(ILogger<ReferenceController> logger, IReferenceService referenceService) : base(logger, referenceService) { }
    }
}
