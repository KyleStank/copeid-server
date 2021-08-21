using CopeID.API.QueryModels;
using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface ISpecimenService : IBaseEntityService<Specimen, SpecimenQueryModel> { }

    public class SpecimenService : BaseEntityService<Specimen, SpecimenQueryModel>, ISpecimenService
    {
        public SpecimenService(CopeIdDbContext context) : base(context) { }
    }
}
