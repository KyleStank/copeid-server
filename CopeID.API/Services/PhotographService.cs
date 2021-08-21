using CopeID.API.QueryModels;
using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IPhotographService : IBaseEntityService<Photograph, PhotographQueryModel> { }

    public class PhotographService : BaseEntityService<Photograph, PhotographQueryModel>, IPhotographService
    {
        public PhotographService(CopeIdDbContext context) : base(context) { }
    }
}
