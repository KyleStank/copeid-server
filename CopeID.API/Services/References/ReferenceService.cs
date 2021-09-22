using CopeID.Context;
using CopeID.Models.References;
using CopeID.QueryModels.References;

namespace CopeID.API.Services.References
{
    public class ReferenceService : BaseQueryableEntityService<Reference, ReferenceQueryModel>, IReferenceService
    {
        public ReferenceService(CopeIdDbContext context) : base(context) { }
    }
}
