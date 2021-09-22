using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Documents;

namespace CopeID.QueryModels.Documents
{
    public class DocumentQueryModel : EntityQueryModel<Document>
    {
        [FromQuery]
        public string[] Name { get; set; } = null;

        [FromQuery]
        public string[] Path { get; set; } = null;

        [FromQuery]
        public string[] MimeType { get; set; } = null;

        protected override IQueryable<Document> GetCustomQuery(IQueryable<Document> query)
        {
            if (Name != null) query = query.Where(e => Name.Contains(e.Name));
            if (Path != null) query = query.Where(e => Path.Contains(e.Path));
            if (MimeType != null) query = query.Where(e => MimeType.Contains(e.MimeType));

            return query;
        }
    }
}
