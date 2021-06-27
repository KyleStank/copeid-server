using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.EntityFrameworkCore;

using CopeID.API.Controllers;
using CopeID.API.Models;

namespace CopeID.API.Services
{
    public interface IBaseCRUDService<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> CreateQuery();

        IEnumerable<TEntity> GetAllEntities();
        Task<TEntity> GetTrackedEntity(Guid id);
        Task<TEntity> GetUntrackedEntity(Guid id, string[] include = null);

        Task<TEntity> CreateEntity(TEntity model);

        Task<TEntity> UpdateEntity(TEntity model);

        Task<TEntity> DeleteEntity(Guid id);
    }

    public abstract class BaseCRUDService<TEntity> : IBaseCRUDService<TEntity> where TEntity : Entity
    {
        protected readonly CopeIdDbContext _context;
        protected readonly DbSet<TEntity> _set;

        protected static readonly IEnumerable<PropertyInfo> _entityProperties = typeof(TEntity).GetProperties().AsEnumerable();

        public BaseCRUDService(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> CreateQuery()
        {
            return _set.AsQueryable();
        }

        public IEnumerable<TEntity> GetAllEntities()
        {
            return _set.AsEnumerable();
        }

        public async Task<TEntity> GetTrackedEntity(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<TEntity> GetUntrackedEntity(Guid id, string[] include = null)
        {
            IQueryable<TEntity> query = _set.AsQueryable().AsNoTracking().Where(x => x.Id == id);
            if (include != null)
            {
                for (int i = 0; i < include.Length; i++)
                {
                    string prop = include[i];
                    if (_entityProperties.Any(x => x.Name == prop))
                    {
                        query = query.Include(prop);
                    }
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> CreateEntity(TEntity model)
        {
            TEntity result = (await _context.AddAsync(model))?.Entity ?? null;
            if (result != null)
            {
                await SaveChanges();
            }

            return result;
        }

        public async Task<TEntity> UpdateEntity(TEntity model)
        {
            if (model == null || !_set.Any(x => x.Id == model.Id))
            {
                return null;
            }

            TEntity result = _set.Update(model)?.Entity ?? null;
            if (result != null)
            {
                await SaveChanges();
            }

            return result;
        }

        public async Task<TEntity> DeleteEntity(Guid id)
        {
            TEntity model = await GetUntrackedEntity(id);
            if (model == null)
            {
                return null;
            }

            TEntity result = _context.Remove(model)?.Entity ?? null;
            if (result != null)
            {
                await SaveChanges();
            }

            return result;
        }

        private async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
