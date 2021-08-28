using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CopeID.Models;
using CopeID.QueryModels;

namespace CopeID.API.Services
{
    public interface IBaseEntityService<TEntity, TQueryModel> : IBaseApiService
        where TEntity : Entity
        where TQueryModel : EntityQueryModel<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(TQueryModel queryModel);
        Task<TEntity> GetTrackedAsync(Guid id);
        Task<TEntity> GetTrackedAsync(Guid id, TQueryModel queryModel);
        Task<TEntity> GetUntrackedAsync(Guid id);
        Task<TEntity> GetUntrackedAsync(Guid id, TQueryModel queryModel);

        Task<TEntity> Create(TEntity model);
        Task<TEntity> Create(TEntity model, TQueryModel queryModel);

        Task<TEntity> Update(TEntity model);
        Task<TEntity> Update(TEntity model, TQueryModel queryModel);

        Task Delete(Guid id);
    }
}
