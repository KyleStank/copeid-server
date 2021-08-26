using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Photographs;

namespace CopeID.API.QueryModels.Photographs
{
    public class PhotographQueryModel : EntityQueryModel<Photograph>
    {
        [FromQuery]
        public string[] Title { get; set; } = null;

        [FromQuery]
        public string[] Description { get; set; } = null;

        [FromQuery]
        public string[] Alt { get; set; } = null;

        [FromQuery]
        public string[] Url { get; set; } = null;

        protected override IQueryable<Photograph> GetCustomQuery(IQueryable<Photograph> query)
        {
            if (Title != null) query = query.Where(e => Title.Contains(e.Title));
            if (Description != null) query = query.Where(e => Description.Contains(e.Description));
            if (Alt != null) query = query.Where(e => Alt.Contains(e.Alt));
            if (Url != null) query = query.Where(e => Url.Contains(e.Url));

            return query;
        }
    }
}
