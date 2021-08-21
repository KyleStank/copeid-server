using CopeID.API.QueryModels;
using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IReferenceService : IBaseEntityService<Reference, ReferenceQueryModel> { }

    public class ReferenceService : BaseEntityService<Reference, ReferenceQueryModel>, IReferenceService
    {
        public ReferenceService(CopeIdDbContext context) : base(context) { }
    }
}
