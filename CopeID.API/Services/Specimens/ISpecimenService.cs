using CopeID.Models.Specimens;
using CopeID.QueryModels.Specimens;

namespace CopeID.API.Services.Specimens
{
    public interface ISpecimenService : IBaseQueryableEntityService<Specimen, SpecimenQueryModel> { }
}
