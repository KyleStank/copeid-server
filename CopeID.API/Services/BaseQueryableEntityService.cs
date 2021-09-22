using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.Context;
using CopeID.Models;
using CopeID.QueryModels;

namespace CopeID.API.Services
{
    public abstract class BaseQueryableEntityService<TEntity, TQueryModel> : BaseEntityService<TEntity>, IBaseQueryableEntityService<TEntity, TQueryModel>
        where TEntity : Entity
        where TQueryModel : EntityQueryModel<TEntity>
    {
        public BaseQueryableEntityService(CopeIdDbContext context) : base(context)
        { }

        public virtual async Task<List<TEntity>> GetAll(TQueryModel queryModel) =>
            await (queryModel != null ? queryModel.FilterQuery(_set.AsTracking()) : _set.AsTracking()).ToListAsync();

        public virtual async Task<TEntity> GetTrackedAsync(Guid id, TQueryModel queryModel) =>
            await FindEntityAsync(id, queryModel, _set.AsTracking());

        public virtual async Task<TEntity> GetUntrackedAsync(Guid id, TQueryModel queryModel) =>
            await FindEntityAsync(id, queryModel, _set.AsNoTracking());

        protected virtual async Task<TEntity> FindEntityAsync(Guid id, TQueryModel queryModel, IQueryable<TEntity> existingQuery = null)
        {
            IQueryable<TEntity> query = existingQuery != null ? existingQuery : _set.AsQueryable();
            return await FindEntityAsync(id, queryModel != null ? queryModel.FilterQuery(query) : query);
        }

        public virtual async Task<TEntity> Create(TEntity model, TQueryModel queryModel)
        {
            TEntity result = await Create(model);
            return await GetUntrackedAsync(result.Id, queryModel);
        }

        public virtual async Task<TEntity> Update(TEntity model, TQueryModel queryModel)
        {
            TEntity result = await Update(model);
            return await GetUntrackedAsync(result.Id, queryModel);
        }
    }
}
