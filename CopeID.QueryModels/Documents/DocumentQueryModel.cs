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

        protected override IQueryable<Document> GetCustomQuery(IQueryable<Document> query)
        {
            if (Name != null) query = query.Where(e => Name.Contains(e.Name));
            if (Path != null) query = query.Where(e => Path.Contains(e.Path));

            return query;
        }
    }
}
