using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services;
using CopeID.Models;

namespace CopeID.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContributorController : BaseEntityController<Contributor, ContributorController, IContributorService>
    {
        public ContributorController(ILogger<ContributorController> logger, IContributorService contributorService)
            : base(logger, contributorService) { }
    }
}
