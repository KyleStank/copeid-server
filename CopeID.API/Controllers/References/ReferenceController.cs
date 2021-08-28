using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.References;
using CopeID.Models.References;
using CopeID.QueryModels.References;

namespace CopeID.API.Controllers.References
{
    [ApiController]
    [Route("[controller]")]
    public class ReferenceController : BaseEntityQueryableController<Reference, ReferenceQueryModel, IReferenceService>
    {
        public ReferenceController(IReferenceService referenceService) : base(referenceService)
        { }
    }
}
