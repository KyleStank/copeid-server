using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using CopeID.Context;
using CopeID.Core.Exceptions;
using CopeID.Models.Filters;

namespace CopeID.API.Services.Filters
{
    public class FilterModelService : IFilterModelService
    {
        protected readonly CopeIdDbContext _context;
        protected readonly DbSet<FilterModel> _set;

        public FilterModelService(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<FilterModel>();
        }

        public async Task<List<FilterModel>> GetAll()
        {
            List<FilterModel> filterModels = await _set.AsNoTracking().ToListAsync();
            return filterModels;
        }

        public async Task<FilterModel> Create(FilterModel model)
        {
            if (model == null) throw new EntityNotCreatedException<FilterModel>("Invalid FilterModel provided");

            FilterModel filterModel = (await _set.AddAsync(model))?.Entity;
            if (filterModel == null) throw new EntityNotCreatedException<FilterModel>();
            else await _context.SaveChangesAsync();

            return filterModel;
        }

        public async Task<FilterModel> Update(FilterModel model)
        {
            if (model == null) throw new EntityNotUpdatedException<FilterModel>("Invalid FilterModel provided");

            FilterModel filterModel = await _set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.Id);
            if (filterModel == null) throw new EntityNotFoundException<FilterModel>();

            filterModel = _set.Update(model)?.Entity;
            if (filterModel == null) throw new EntityNotUpdatedException<FilterModel>();
            else await _context.SaveChangesAsync();

            return filterModel;
        }

        public async Task Delete(Guid id)
        {
            FilterModel model = await _set.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (model == null) throw new EntityNotFoundException<FilterModel>();

            FilterModel filterModel = _set.Remove(model)?.Entity;
            if (filterModel == null) throw new EntityNotDeletedException<FilterModel>();
            else await _context.SaveChangesAsync();
        }
    }
}
