using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.EntityFrameworkCore;

using CopeID.API.Models;

namespace CopeID.API.Services
{
    public interface IGenusService : IBaseCRUDService<Genus> { }

    public class GenusService : BaseCRUDService<Genus>, IGenusService
    {
        public GenusService(CopeIdDbContext context) : base(context) { }
    }

    //public interface IGenusService
    //{
    //    Task<Genus> GetGenus(Guid id);
    //}

    //public class GenusService : IGenusService
    //{
    //    private readonly CopeIdDbContext _context;
    //    private readonly DbSet<Genus> _set;

    //    public GenusService(CopeIdDbContext context)
    //    {
    //        _context = context;
    //        _set = _context.Set<Genus>();
    //    }

    //    public async Task<Genus> GetGenus(Guid id)
    //    {
    //        IEnumerable<PropertyInfo> props = typeof(Genus).GetProperties().Where(x => x.IsDefined(typeof(AutoIncludeAttribute), true));
    //        var pArray = props.ToArray();

    //        Genus result = await _set.Where(x => x.Id == id)
    //            .Include(x => x.Photograph)
    //            .Include(x => x.Specimens)
    //            .FirstOrDefaultAsync();
    //        return result;
    //    }
    //}
}
