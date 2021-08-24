using CopeID.API.QueryModels;
using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IContributorService : IBaseEntityService<Contributor, ContributorQueryModel> { }

    public class ContributorService : BaseEntityService<Contributor, ContributorQueryModel>, IContributorService
    {
        public ContributorService(CopeIdDbContext context) : base(context) { }
    }
}
