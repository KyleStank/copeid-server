using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Definitions;

namespace CopeID.QueryModels.Definitions
{
    public class DefinitionQueryModel : EntityQueryModel<Definition>
    {
        [FromQuery]
        public string[] Name { get; set; } = null;

        [FromQuery]
        public string[] Meaning { get; set; } = null;

        protected override IQueryable<Definition> GetCustomQuery(IQueryable<Definition> query)
        {
            if (Name != null) query = query.Where(e => Name.Contains(e.Name));
            if (Meaning != null) query = query.Where(e => Meaning.Contains(e.Meaning));

            return query;
        }
    }
}
