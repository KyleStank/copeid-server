using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IGenusService : IBaseEntityService<Genus> { }

    public class GenusService : BaseEntityService<Genus>, IGenusService
    {
        public GenusService(CopeIdDbContext context) : base(context) { }
    }
}
