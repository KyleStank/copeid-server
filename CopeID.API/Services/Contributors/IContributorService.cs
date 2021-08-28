using CopeID.Models.Contributors;
using CopeID.QueryModels.Contributors;

namespace CopeID.API.Services.Contributors
{
    public interface IContributorService : IBaseQueryableEntityService<Contributor, ContributorQueryModel> { }
}
