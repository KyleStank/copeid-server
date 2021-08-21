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
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(EntityQueryModel query);
        Task<TEntity> GetEntityTrackedAsync(Guid id, string[] include = null);
        Task<TEntity> GetEntityUntrackedAsync(Guid id, string[] include = null);

        Task<TEntity> CreateEntity(TEntity model);

        Task<TEntity> UpdateEntity(TEntity model);

        Task<TEntity> DeleteEntity(Guid id);
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

        public IEnumerable<TEntity> GetAll() => GetAll(null);

        public IEnumerable<TEntity> GetAll(EntityQueryModel queryModel) => CreateFilteredQuery(queryModel, _set.AsTracking()).AsEnumerable();

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

        public async Task<TEntity> GetEntityTrackedAsync(Guid id, string[] include = null) =>
            await FindEntityAsync(id, _set.AsTracking(), include);

        public async Task<TEntity> GetEntityUntrackedAsync(Guid id, string[] include = null) =>
            await FindEntityAsync(id, _set.AsNoTracking(), include);

        protected async Task<TEntity> FindEntityAsync(Guid id, IQueryable<TEntity> query, string[] include = null)
        {
            TEntity result = await GenerateIncludeQuery(include, query.Where(x => x.Id == id)).FirstOrDefaultAsync();
            if (result == null) throw new EntityNotFoundException<TEntity>();

            return result;
        }

        public async Task<TEntity> CreateEntity(TEntity model)
        {
            TEntity result = (await _context.AddAsync(model))?.Entity ?? null;
            if (result != null) await SaveChanges();
            else throw new EntityNotCreatedException<TEntity>();

            return result;
        }

        public async Task<TEntity> UpdateEntity(TEntity model)
        {
            if (model == null || !_set.Any(x => x.Id == model.Id)) throw new EntityNotFoundException<TEntity>();

            TEntity result = _set.Update(model)?.Entity ?? null;
            if (result != null) await SaveChanges();
            else throw new EntityNotUpdatedException<TEntity>();

            return result;
        }

        public async Task<TEntity> DeleteEntity(Guid id)
        {
            TEntity model = await GetEntityUntrackedAsync(id);
            if (model == null) throw new EntityNotFoundException<TEntity>();

            TEntity result = _context.Remove(model)?.Entity ?? null;
            if (result != null) await SaveChanges();
            else throw new EntityNotDeletedException<TEntity>();

            return result;
        }

        protected IQueryable<TEntity> GenerateIncludeQuery(string[] include, IQueryable<TEntity> existingQuery = null)
        {
            IQueryable<TEntity> query = existingQuery ?? _set.AsQueryable();
            if (include != null)
            {
                string[] validIncludeProperties = include.Where(s => _entityProperties.Any(p => p.Name == s)).ToArray();
                foreach (string prop in validIncludeProperties)
                    query = query.Include(prop);
            }
            return query;
        }

        protected async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
