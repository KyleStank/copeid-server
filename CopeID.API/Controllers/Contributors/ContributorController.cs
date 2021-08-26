using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using CopeID.API.Services.Contributors;
using CopeID.Models.Contributors;
using CopeID.QueryModels.Contributors;

namespace CopeID.API.Controllers.Contributors
{
    [ApiController]
    [Route("[controller]")]
    public class ContributorController : BaseEntityController<Contributor, ContributorQueryModel, ContributorController, IContributorService>
    {
        public ContributorController(ILogger<ContributorController> logger, IContributorService contributorService)
            : base(logger, contributorService) { }
    }
}
