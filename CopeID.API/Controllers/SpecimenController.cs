using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Models;
using CopeID.API.Services;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecimenController : BaseCrudController<Specimen, SpecimenController, ISpecimenService>
    {
        public SpecimenController(ILogger<SpecimenController> logger, ISpecimenService specimenService) : base(logger, specimenService) { }
    }
}
