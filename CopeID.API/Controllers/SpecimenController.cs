using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services;
using CopeID.API.QueryModels;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecimenController : BaseEntityController<Specimen, SpecimenQueryModel, SpecimenController, ISpecimenService>
    {
        public SpecimenController(ILogger<SpecimenController> logger, ISpecimenService specimenService) : base(logger, specimenService) { }
    }
}
