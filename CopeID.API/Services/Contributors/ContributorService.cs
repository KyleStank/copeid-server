using CopeID.Context;
using CopeID.Models.Contributors;
using CopeID.QueryModels.Contributors;

namespace CopeID.API.Services.Contributors
{
    public class ContributorService : BaseEntityService<Contributor, ContributorQueryModel>, IContributorService
    {
        public ContributorService(CopeIdDbContext context) : base(context) { }
    }
}
