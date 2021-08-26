using CopeID.API.QueryModels.References;
using CopeID.Context;
using CopeID.Models.References;

namespace CopeID.API.Services.References
{
    public class ReferenceService : BaseEntityService<Reference, ReferenceQueryModel>, IReferenceService
    {
        public ReferenceService(CopeIdDbContext context) : base(context) { }
    }
}
