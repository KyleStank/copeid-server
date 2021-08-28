using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Specimens;
using CopeID.Models.Specimens;
using CopeID.QueryModels.Specimens;

namespace CopeID.API.Controllers.Specimens
{
    [ApiController]
    [Route("[controller]")]
    public class SpecimenController : BaseEntityController<Specimen, SpecimenQueryModel, ISpecimenService>
    {
        public SpecimenController(ISpecimenService specimenService) : base(specimenService)
        { }
    }
}
