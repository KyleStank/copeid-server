using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services;
using CopeID.API.QueryModels;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotographController : BaseEntityController<Photograph, PhotographQueryModel, PhotographController, IPhotographService>
    {
        public PhotographController(ILogger<PhotographController> logger, IPhotographService photographService) : base(logger, photographService) { }
    }
}
