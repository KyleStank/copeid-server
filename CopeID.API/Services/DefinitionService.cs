using CopeID.Context;
using CopeID.Models;

namespace CopeID.API.Services
{
    public interface IDefinitionService : IBaseEntityService<Definition> { }

    public class DefinitionService : BaseEntityService<Definition>, IDefinitionService
    {
        public DefinitionService(CopeIdDbContext context) : base(context) { }
    }
}
