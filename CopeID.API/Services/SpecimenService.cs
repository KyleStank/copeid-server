using CopeID.API.Models;

namespace CopeID.API.Services
{
    public interface ISpecimenService : IBaseCrudService<Specimen> { }

    public class SpecimenService : BaseCrudService<Specimen>, ISpecimenService
    {
        public SpecimenService(CopeIdDbContext context) : base(context) { }
    }
}
