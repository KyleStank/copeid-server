using CopeID.API.Models;

namespace CopeID.API.Services
{
    public interface IPhotographService : IBaseCRUDService<Photograph> { }

    public class PhotographService : BaseCRUDService<Photograph>, IPhotographService
    {
        public PhotographService(CopeIdDbContext context) : base(context) { }
    }
}
