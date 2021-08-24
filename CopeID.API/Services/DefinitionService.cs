using CopeID.API.QueryModels;
using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IDefinitionService : IBaseEntityService<Definition, DefinitionQueryModel> { }

    public class DefinitionService : BaseEntityService<Definition, DefinitionQueryModel>, IDefinitionService
    {
        public DefinitionService(CopeIdDbContext context) : base(context) { }
    }
}
