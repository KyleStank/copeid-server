using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.AzureStorage;
using CopeID.API.Services.Specimens;
using CopeID.Models.Specimens;
using CopeID.QueryModels.Specimens;

namespace CopeID.API.Controllers.Specimens
{
    [ApiController]
    [Route("[controller]")]
    public class SpecimenController : BaseEntityQueryableController<Specimen, SpecimenQueryModel, ISpecimenService>
    {
        private readonly IAzureStorageService _azureStorageService;

        public SpecimenController(ISpecimenService specimenService, IAzureStorageService azureStorageService) : base(specimenService)
        {
            _azureStorageService = azureStorageService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<IActionResult> Get([FromQuery] SpecimenQueryModel queryModel)
        {
            List<Specimen> entities = await _entityService.GetAll(queryModel);
            return Ok(entities);
        }
    }
}
