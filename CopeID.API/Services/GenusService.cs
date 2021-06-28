using CopeID.API.Models;

namespace CopeID.API.Services
{
    public interface IGenusService : IBaseCrudService<Genus> { }

    public class GenusService : BaseCrudService<Genus>, IGenusService
    {
        public GenusService(CopeIdDbContext context) : base(context) { }
    }
}
