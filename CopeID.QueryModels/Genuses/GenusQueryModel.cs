using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Genuses;

namespace CopeID.QueryModels.Genuses
{
    public class GenusQueryModel : EntityQueryModel<Genus>
    {
        [FromQuery]
        public Guid?[] PhotographId { get; set; } = null;

        [FromQuery]
        public string[] Name { get; set; } = null;

        protected override IQueryable<Genus> GetCustomQuery(IQueryable<Genus> query)
        {
            if (PhotographId != null) query = query.Where(e => PhotographId.Contains(e.PhotographId));
            if (Name != null) query = query.Where(e => Name.Contains(e.Name));

            return query;
        }
    }
}
