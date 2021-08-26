using CopeID.API.QueryModels.Photographs;
using CopeID.Context;
using CopeID.Models.Photographs;

namespace CopeID.API.Services.Photographs
{
    public interface IPhotographService : IBaseEntityService<Photograph, PhotographQueryModel> { }

    public class PhotographService : BaseEntityService<Photograph, PhotographQueryModel>, IPhotographService
    {
        public PhotographService(CopeIdDbContext context) : base(context) { }
    }
}
