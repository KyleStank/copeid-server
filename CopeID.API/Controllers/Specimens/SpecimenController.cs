using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services.Specimens;
using CopeID.Models.Specimens;
using CopeID.QueryModels.Specimens;

namespace CopeID.API.Controllers.Specimens
{
    [ApiController]
    [Route("[controller]")]
    public class SpecimenController : BaseEntityController<Specimen, SpecimenQueryModel, SpecimenController, ISpecimenService>
    {
        public SpecimenController(ILogger<SpecimenController> logger, ISpecimenService specimenService) : base(logger, specimenService) { }
    }
}
