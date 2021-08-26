using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Contributors;

namespace CopeID.QueryModels.Contributors
{
    public class ContributorQueryModel : EntityQueryModel<Contributor>
    {
        [FromQuery]
        public string[] Name { get; set; } = null;

        protected override IQueryable<Contributor> GetCustomQuery(IQueryable<Contributor> query)
        {
            if (Name != null) query = query.Where(e => Name.Contains(e.Name));

            return query;
        }
    }
}
