using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CopeID.Models;
using CopeID.QueryModels;

namespace CopeID.API.Services
{
    public interface IBaseQueryableEntityService<TEntity, TQueryModel> : IBaseEntityService<TEntity>
        where TEntity : Entity
        where TQueryModel : EntityQueryModel<TEntity>
    {
        Task<List<TEntity>> GetAll(TQueryModel queryModel);
        Task<TEntity> GetTrackedAsync(Guid id, TQueryModel queryModel);
        Task<TEntity> GetUntrackedAsync(Guid id, TQueryModel queryModel);

        Task<TEntity> Create(TEntity model, TQueryModel queryModel);

        Task<TEntity> Update(TEntity model, TQueryModel queryModel);
    }
}
