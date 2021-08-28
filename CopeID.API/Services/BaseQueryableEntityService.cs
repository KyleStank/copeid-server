﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.Core.Exceptions;
using CopeID.Context;
using CopeID.Models;
using CopeID.QueryModels;

namespace CopeID.API.Services
{
    public abstract class BaseQueryableEntityService<TEntity, TQueryModel> : IBaseQueryableEntityService<TEntity, TQueryModel>
        where TEntity : Entity
        where TQueryModel : EntityQueryModel<TEntity>
    {
        protected readonly CopeIdDbContext _context;
        protected readonly DbSet<TEntity> _set;

        public BaseQueryableEntityService(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll() =>
            await GetAll(null);

        public async Task<List<TEntity>> GetAll(TQueryModel queryModel) =>
            await (queryModel != null ? queryModel.FilterQuery(_set.AsTracking()) : _set.AsTracking()).ToListAsync();

        public async Task<TEntity> GetTrackedAsync(Guid id) =>
            await GetTrackedAsync(id, null);

        public async Task<TEntity> GetTrackedAsync(Guid id, TQueryModel queryModel) =>
            await FindEntityAsync(id, queryModel, _set.AsTracking());

        public async Task<TEntity> GetUntrackedAsync(Guid id) =>
            await GetUntrackedAsync(id, null);

        public async Task<TEntity> GetUntrackedAsync(Guid id, TQueryModel queryModel) =>
            await FindEntityAsync(id, queryModel, _set.AsNoTracking());

        protected async Task<TEntity> FindEntityAsync(Guid id, TQueryModel queryModel, IQueryable<TEntity> existingQuery = null)
        {
            IQueryable<TEntity> query = existingQuery != null ? existingQuery : _set.AsQueryable();
            TEntity result = await (queryModel != null ? queryModel.FilterQuery(query) : query).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (result == null) throw new EntityNotFoundException<TEntity>();

            return result;
        }

        public async Task<TEntity> Create(TEntity model) =>
            await Create(model, null);

        public async Task<TEntity> Create(TEntity model, TQueryModel queryModel)
        {
            TEntity result = (await _context.AddAsync(model))?.Entity ?? null;
            if (result != null) await _context.SaveChangesAsync();
            else throw new EntityNotCreatedException<TEntity>();

            return await GetUntrackedAsync(result.Id, queryModel);
        }

        public async Task<TEntity> Update(TEntity model) =>
            await Update(model, null);

        public async Task<TEntity> Update(TEntity model, TQueryModel queryModel)
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