using System.Threading.Tasks;

using CopeID.Models;

namespace CopeID.API.Services.Filters
{
    public interface IEntityFilterService<TEntity> : ICustomFilterService where TEntity : Entity
    {
        Task<TEntity> FilterForEntity(TEntity model);
    }
}
