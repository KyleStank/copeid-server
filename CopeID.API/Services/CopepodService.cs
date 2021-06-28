using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CopeID.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CopeID.API.Services
{
    public interface ICopepodService
    {
        IEnumerable<Copepod> GetAllCopepods();
        Task<Copepod> GetTrackedCopepod(Guid id);
        Task<Copepod> GetUntrackedCopepod(Guid id);

        Task<Copepod> CreateCopepod(Copepod model);

        Task<Copepod> UpdateCopeod(Copepod model);

        Task<Copepod> DeleteCopepod(Guid id);
    }

    public class CopepodService : ICopepodService
    {
        private readonly CopeIdDbContext _context;
        private readonly DbSet<Copepod> _set;

        public CopepodService(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<Copepod>();
        }

        public IEnumerable<Copepod> GetAllCopepods()
        {
            return _set.AsEnumerable();
        }

        public async Task<Copepod> GetTrackedCopepod(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<Copepod> GetUntrackedCopepod(Guid id)
        {
            return await _set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Copepod> CreateCopepod(Copepod model)
        {
            Copepod result = (await _context.AddAsync(model))?.Entity ?? null;
            if (result != null)
            {
                await SaveChanges();
            }

            return result;
        }

        public async Task<Copepod> UpdateCopeod(Copepod model)
        {
            if (model == null || !_set.Any(x => x.Id == model.Id))
            {
                return null;
            }

            Copepod result = _set.Update(model)?.Entity ?? null;
            if (result != null)
            {
                await SaveChanges();
            }

            return result;
        }

        public async Task<Copepod> DeleteCopepod(Guid id)
        {
            Copepod model = await GetUntrackedCopepod(id);
            if (model == null)
            {
                return null;
            }

            Copepod result = _context.Remove(model)?.Entity ?? null;
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
