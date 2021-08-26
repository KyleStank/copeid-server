using CopeID.Context;
using CopeID.Models.Genuses;
using CopeID.QueryModels.Genuses;

namespace CopeID.API.Services.Genuses
{
    public class GenusService : BaseEntityService<Genus, GenusQueryModel>, IGenusService
    {
        public GenusService(CopeIdDbContext context) : base(context) { }
    }
}
