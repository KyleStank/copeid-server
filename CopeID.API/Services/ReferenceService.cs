using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IReferenceService : IBaseEntityService<Reference> { }

    public class ReferenceService : BaseEntityService<Reference>, IReferenceService
    {
        public ReferenceService(CopeIdDbContext context) : base(context) { }
    }
}
