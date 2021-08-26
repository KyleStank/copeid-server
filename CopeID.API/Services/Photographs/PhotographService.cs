using CopeID.Context;
using CopeID.Models.Photographs;
using CopeID.QueryModels.Photographs;

namespace CopeID.API.Services.Photographs
{
    public class PhotographService : BaseEntityService<Photograph, PhotographQueryModel>, IPhotographService
    {
        public PhotographService(CopeIdDbContext context) : base(context) { }
    }
}
