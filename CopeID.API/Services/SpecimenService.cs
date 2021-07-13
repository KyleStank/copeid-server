using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface ISpecimenService : IBaseEntityService<Specimen> { }

    public class SpecimenService : BaseEntityService<Specimen>, ISpecimenService
    {
        public SpecimenService(CopeIdDbContext context) : base(context) { }
    }
}
