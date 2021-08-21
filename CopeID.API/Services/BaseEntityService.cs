using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.EntityFrameworkCore;

using CopeID.API.QueryModels;
using CopeID.Core.Exceptions;
using CopeID.Context;
using CopeID.Extensions;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IBaseEntityService<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(EntityQueryModel queryModel);
        Task<TEntity> GetTrackedAsync(Guid id);
        Task<TEntity> GetTrackedAsync(Guid id, EntityQueryModel queryModel);
        Task<TEntity> GetUntrackedAsync(Guid id);
        Task<TEntity> GetUntrackedAsync(Guid id, EntityQueryModel queryModel);

        Task<TEntity> Create(TEntity model);
        Task<TEntity> Create(TEntity model, EntityQueryModel queryModel);

        Task<TEntity> Update(TEntity model);
        Task<TEntity> Update(TEntity model, EntityQueryModel queryModel);

        Task Delete(Guid id);
    }

    public abstract class BaseEntityService<TEntity> : IBaseEntityService<TEntity> where TEntity : Entity
    {
        protected readonly CopeIdDbContext _context;
        protected readonly DbSet<TEntity> _set;

        protected static readonly Type _entityType = typeof(TEntity);
        protected static readonly IEnumerable<PropertyInfo> _entityProperties = _entityType.GetProperties().AsEnumerable();

        public BaseEntityService(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll() =>
            await GetAll(null);

        public async Task<List<TEntity>> GetAll(EntityQueryModel queryModel) =>
            await CreateFilteredQuery(queryModel, _set.AsTracking()).ToListAsync();

        protected IQueryable<TEntity> CreateFilteredQuery(EntityQueryModel queryModel, IQueryable<TEntity> existingQuery = null)
        {
            IQueryable<TEntity> query = existingQuery ?? _set.AsQueryable();
            if (queryModel != null)
            {
                if (queryModel.Ids != null) query = query.Where(e => queryModel.Ids.Contains(e.Id));

                if (queryModel.Include != null)
                {
                    string[] includeProperties = FindValidProperties(queryModel.Include.ToPascalCase());
                    foreach (string prop in includeProperties) query = query.Include(prop);
                }

                if (queryModel.OrderBy != null || queryModel.OrderByDescending != null)
                {
                    // Order query ascendingly.
                    string[] ascendingProperties = FindValidProperties(queryModel.OrderBy?.ToPascalCase());
                    for (int i = 0; i < ascendingProperties.Length; i++)
                    {
                        string prop = ascendingProperties[i];
                        if (i == 0)
                        {
                            query = query.OrderBy(prop);
                            continue;
                        }

                        query = query.ThenBy(prop);
                    }

                    // Order query descendingly.
                    string[] descendingProperties = FindValidProperties(queryModel.OrderByDescending?.ToPascalCase());
                    for (int i = 0; i < descendingProperties.Length; i++)
                    {
                        string prop = descendingProperties[i];
                        if (i == 0 && ascendingProperties.Length == 0)
                        {
                            query = query.OrderByDescending(prop);
                            continue;
                        }

                        query = query.ThenByDescending(prop);
                    }
                }
            }
            return query;
        }

        protected string[] FindValidProperties(string[] properties) =>
            properties?.Where(x => _entityProperties.Any(p => p.Name == x)).ToArray() ?? new string[0];

        public async Task<TEntity> GetTrackedAsync(Guid id) =>
            await GetTrackedAsync(id, null);

        public async Task<TEntity> GetTrackedAsync(Guid id, EntityQueryModel queryModel) =>
            await FindEntityAsync(id, queryModel, _set.AsTracking());

        public async Task<TEntity> GetUntrackedAsync(Guid id) =>
            await GetUntrackedAsync(id, null);

        public async Task<TEntity> GetUntrackedAsync(Guid id, EntityQueryModel queryModel) =>
            await FindEntityAsync(id, queryModel, _set.AsNoTracking());

        protected async Task<TEntity> FindEntityAsync(Guid id, EntityQueryModel queryModel, IQueryable<TEntity> existingQuery = null)
        {
            TEntity result = await CreateFilteredQuery(queryModel, (existingQuery != null ? existingQuery : _set.AsQueryable()).Where(x => x.Id == id)).FirstOrDefaultAsync();
            if (result == null) throw new EntityNotFoundException<TEntity>();

            return result;
        }

        public async Task<TEntity> Create(TEntity model) =>
            await Create(model, null);

        public async Task<TEntity> Create(TEntity model, EntityQueryModel queryModel)
        {
            TEntity result = (await _context.AddAsync(model))?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotCreatedException<TEntity>();

            return await GetUntrackedAsync(result.Id, queryModel);
        }

        public async Task<TEntity> Update(TEntity model) =>
            await Update(model, null);

        public async Task<TEntity> Update(TEntity model, EntityQueryModel queryModel)
        {
            if (model == null || !_set.Any(x => x.Id == model.Id)) throw new EntityNotFoundException<TEntity>();

            TEntity result = _set.Update(model)?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotUpdatedException<TEntity>();

            return await GetUntrackedAsync(result.Id, queryModel);
        }

        public async Task Delete(Guid id)
        {
            TEntity model = await GetUntrackedAsync(id);
            if (model == null) throw new EntityNotFoundException<TEntity>();

            TEntity result = _context.Remove(model)?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotDeletedException<TEntity>();
        }
    }
}
