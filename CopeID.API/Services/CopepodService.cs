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
        Task<Copepod> GetCopepod(Guid id);
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

        public async Task<Copepod> GetCopepod(Guid id)
        {
            return await _set.FindAsync(id);
        }
    }
}
