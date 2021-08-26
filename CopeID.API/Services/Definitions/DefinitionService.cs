using CopeID.API.QueryModels.Definitions;
using CopeID.Context;
using CopeID.Models.Definitions;

namespace CopeID.API.Services.Definitions
{
    public class DefinitionService : BaseEntityService<Definition, DefinitionQueryModel>, IDefinitionService
    {
        public DefinitionService(CopeIdDbContext context) : base(context) { }
    }
}
