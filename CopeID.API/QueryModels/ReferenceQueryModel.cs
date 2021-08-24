using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models;

namespace CopeID.API.QueryModels
{
    public class ReferenceQueryModel : EntityQueryModel<Reference>
    {
        [FromQuery]
        public string[] Content { get; set; } = null;

        protected override IQueryable<Reference> GetCustomQuery(IQueryable<Reference> query)
        {
            if (Content != null) query = query.Where(e => Content.Contains(e.Content));

            return query;
        }
    }
}
