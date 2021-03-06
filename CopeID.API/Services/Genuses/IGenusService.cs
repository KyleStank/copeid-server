using CopeID.Models.Genuses;
using CopeID.QueryModels.Genuses;

namespace CopeID.API.Services.Genuses
{
    public interface IGenusService : IBaseQueryableEntityService<Genus, GenusQueryModel> { }
}
