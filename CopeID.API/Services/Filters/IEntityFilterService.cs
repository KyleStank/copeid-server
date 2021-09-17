using System.Threading.Tasks;

using CopeID.API.FilterModels;
using CopeID.Models;

namespace CopeID.API.Services.Filters
{
    public interface IEntityFilterService<TEntity, TEntityFilter> : ICustomFilterService
        where TEntity : Entity
        where TEntityFilter : IFilterModel
    {
        Task<TEntity> FilterForEntity(TEntityFilter model);
    }
}
