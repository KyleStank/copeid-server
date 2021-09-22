using Microsoft.AspNetCore.Mvc;

using CopeID.API.Services.Contributors;
using CopeID.Models.Contributors;
using CopeID.QueryModels.Contributors;

namespace CopeID.API.Controllers.Contributors
{
    [ApiController]
    [Route("[controller]")]
    public class ContributorController : BaseEntityQueryableController<Contributor, ContributorQueryModel, IContributorService>
    {
        public ContributorController(IContributorService contributorService) : base(contributorService)
        { }
    }
}
