using CopeID.API.QueryModels.Specimens;
using CopeID.Context;
using CopeID.Models.Specimens;

namespace CopeID.API.Services.Specimens
{
    public interface ISpecimenService : IBaseEntityService<Specimen, SpecimenQueryModel> { }

    public class SpecimenService : BaseEntityService<Specimen, SpecimenQueryModel>, ISpecimenService
    {
        public SpecimenService(CopeIdDbContext context) : base(context) { }
    }
}
