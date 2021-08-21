using CopeID.API.QueryModels;
using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IGenusService : IBaseEntityService<Genus, GenusQueryModel> { }

    public class GenusService : BaseEntityService<Genus, GenusQueryModel>, IGenusService
    {
        public GenusService(CopeIdDbContext context) : base(context) { }
    }
}
