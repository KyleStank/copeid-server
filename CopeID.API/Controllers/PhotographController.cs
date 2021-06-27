using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Models;
using CopeID.API.Services;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotographController : BaseCRUDController<Photograph, PhotographController, IPhotographService>
    {
        public PhotographController(ILogger<PhotographController> logger, IPhotographService photographService) : base(logger, photographService) { }
    }
}
