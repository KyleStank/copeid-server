using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.API.Models;

namespace CopeID.API.Services
{
    public interface IBaseCRUDService<T>
    {
        IEnumerable<T> GetAllEntities();
        Task<T> GetTrackedEntity(Guid id);
        Task<T> GetUntrackedEntity(Guid id);

        Task<T> CreateEntity(T model);

        Task<T> UpdateEntity(T model);

        Task<T> DeleteEntity(Guid id);
    }

    public abstract class BaseCRUDService<T> : IBaseCRUDService<T> where T : Entity
    {
        protected readonly CopeIdDbContext _context;
        protected readonly DbSet<T> _set;

        public BaseCRUDService(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public IEnumerable<T> GetAllEntities()
        {
            return _set.AsEnumerable();
        }

        public async Task<T> GetTrackedEntity(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<T> GetUntrackedEntity(Guid id)
        {
            return await _set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> CreateEntity(T model)
        {
            T result = (await _context.AddAsync(model))?.Entity ?? null;
            if (result != null)
            {
                await SaveChanges();
            }

            return result;
        }

        public async Task<T> UpdateEntity(T model)
        {
            if (model == null || !_set.Any(x => x.Id == model.Id))
            {
                return null;
            }

            T result = _set.Update(model)?.Entity ?? null;
            if (result != null)
            {
                await SaveChanges();
            }

            return result;
        }

        public async Task<T> DeleteEntity(Guid id)
        {
            T model = await GetUntrackedEntity(id);
            if (model == null)
            {
                return null;
            }

            T result = _context.Remove(model)?.Entity ?? null;
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
