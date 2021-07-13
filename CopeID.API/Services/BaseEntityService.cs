using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.EntityFrameworkCore;

using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IBaseEntityService<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAllEntities(string[] include = null);
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

        protected static readonly IEnumerable<PropertyInfo> _entityProperties = typeof(TEntity).GetProperties().AsEnumerable();

        public BaseEntityService(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAllEntities(string[] include = null) =>
            GenerateIncludeQuery(include, _set.AsTracking()).AsEnumerable();

        public async Task<TEntity> GetEntityTrackedAsync(Guid id, string[] include = null) =>
            await FindEntityAsync(id, _set.AsTracking(), include);

        public async Task<TEntity> GetEntityUntrackedAsync(Guid id, string[] include = null) =>
            await FindEntityAsync(id, _set.AsNoTracking(), include);

        protected async Task<TEntity> FindEntityAsync(Guid id, IQueryable<TEntity> query, string[] include = null) =>
            await GenerateIncludeQuery(include, query.Where(x => x.Id == id)).FirstOrDefaultAsync();

        public async Task<TEntity> CreateEntity(TEntity model)
        {
            TEntity result = (await _context.AddAsync(model))?.Entity ?? null;
            if (result != null) await SaveChanges();

            return result;
        }

        public async Task<TEntity> UpdateEntity(TEntity model)
        {
            if (model == null || !_set.Any(x => x.Id == model.Id)) return null;

            TEntity result = _set.Update(model)?.Entity ?? null;
            if (result != null) await SaveChanges();

            return result;
        }

        public async Task<TEntity> DeleteEntity(Guid id)
        {
            TEntity model = await GetEntityUntrackedAsync(id);
            if (model == null) return null;

            TEntity result = _context.Remove(model)?.Entity ?? null;
            if (result != null) await SaveChanges();

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
