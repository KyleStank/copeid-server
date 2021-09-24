using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Photographs;

namespace CopeID.QueryModels.Photographs
{
    public class PhotographQueryModel : EntityQueryModel<Photograph>
    {
        [FromQuery]
        public Guid[] DocumentId { get; set; } = null;

        [FromQuery]
        public string[] Title { get; set; } = null;

        [FromQuery]
        public string[] Description { get; set; } = null;

        protected override IQueryable<Photograph> GetCustomQuery(IQueryable<Photograph> query)
        {
            if (DocumentId != null) query = query.Where(e => DocumentId.Contains(e.DocumentId));
            if (Title != null) query = query.Where(e => Title.Contains(e.Title));
            if (Description != null) query = query.Where(e => Description.Contains(e.Description));

            return query;
        }
    }
}
