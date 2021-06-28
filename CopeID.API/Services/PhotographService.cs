using CopeID.API.Models;

namespace CopeID.API.Services
{
    public interface IPhotographService : IBaseCrudService<Photograph> { }

    public class PhotographService : BaseCrudService<Photograph>, IPhotographService
    {
        public PhotographService(CopeIdDbContext context) : base(context) { }
    }
}
