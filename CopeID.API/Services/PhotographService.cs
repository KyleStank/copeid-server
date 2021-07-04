using CopeID.API.Models;

namespace CopeID.API.Services
{
    public interface IPhotographService : IBaseEntityService<Photograph> { }

    public class PhotographService : BaseEntityService<Photograph>, IPhotographService
    {
        public PhotographService(CopeIdDbContext context) : base(context) { }
    }
}
