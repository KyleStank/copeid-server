using CopeID.API.QueryModels.Contributors;
using CopeID.Context;
using CopeID.Models.Contributors;

namespace CopeID.API.Services.Contributors
{
    public interface IContributorService : IBaseEntityService<Contributor, ContributorQueryModel> { }

    public class ContributorService : BaseEntityService<Contributor, ContributorQueryModel>, IContributorService
    {
        public ContributorService(CopeIdDbContext context) : base(context) { }
    }
}
