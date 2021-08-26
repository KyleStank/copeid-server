using CopeID.Context;
using CopeID.Models.Specimens;
using CopeID.QueryModels.Specimens;

namespace CopeID.API.Services.Specimens
{
    public class SpecimenService : BaseEntityService<Specimen, SpecimenQueryModel>, ISpecimenService
    {
        public SpecimenService(CopeIdDbContext context) : base(context) { }
    }
}
