using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IContributorService : IBaseEntityService<Contributor> { }

    public class ContributorService : BaseEntityService<Contributor>, IContributorService
    {
        public ContributorService(CopeIdDbContext context) : base(context) { }
    }
}
