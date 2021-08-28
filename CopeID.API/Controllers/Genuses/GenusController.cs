using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Genuses;
using CopeID.Models.Genuses;
using CopeID.QueryModels.Genuses;

namespace CopeID.API.Controllers.Genuses
{
    [ApiController]
    [Route("[controller]")]
    public class GenusController : BaseEntityController<Genus, GenusQueryModel, IGenusService>
    {
        public GenusController(IGenusService genusService) : base(genusService)
        { }
    }
}
