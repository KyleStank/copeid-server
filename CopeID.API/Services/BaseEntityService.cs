using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.Core.Exceptions;
using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public abstract class BaseEntityService<TEntity> : IBaseEntityService<TEntity>
        where TEntity : Entity
    {
        protected readonly CopeIdDbContext _context;
        protected readonly DbSet<TEntity> _set;

        public BaseEntityService(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll() =>
            await _set.AsTracking().ToListAsync();

        public virtual async Task<TEntity> GetTrackedAsync(Guid id) =>
            await FindEntityAsync(id, _set.AsTracking());

        public virtual async Task<TEntity> GetUntrackedAsync(Guid id) =>
            await FindEntityAsync(id, _set.AsNoTracking());

        protected virtual async Task<TEntity> FindEntityAsync(Guid id, IQueryable<TEntity> existingQuery = null)
        {
            IQueryable<TEntity> query = existingQuery != null ? existingQuery : _set.AsQueryable();
            TEntity result = await query.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null) throw new EntityNotFoundException<TEntity>();

            return result;
        }

        public virtual async Task<TEntity> Create(TEntity model)
        {
            TEntity result = (await _context.AddAsync(model))?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotCreatedException<TEntity>();

            return result;
        }

        public virtual async Task<TEntity> Update(TEntity model)
        {
            if (model == null || !_set.Any(x => x.Id == model.Id)) throw new EntityNotFoundException<TEntity>();

            TEntity result = _set.Update(model)?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotUpdatedException<TEntity>();

            return result;
        }

        public virtual async Task Delete(Guid id)
        {
            TEntity model = await GetUntrackedAsync(id);
            if (model == null) throw new EntityNotFoundException<TEntity>();

            TEntity result = _context.Remove(model)?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotDeletedException<TEntity>();
        }
    }
}
