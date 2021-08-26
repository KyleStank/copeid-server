using CopeID.API.QueryModels.Specimens;
using CopeID.Models.Specimens;

namespace CopeID.API.Services.Specimens
{
    public interface ISpecimenService : IBaseEntityService<Specimen, SpecimenQueryModel> { }
}
