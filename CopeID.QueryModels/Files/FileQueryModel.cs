using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Files;

namespace CopeID.QueryModels.Files
{
    public class FileQueryModel : EntityQueryModel<File>
    {
        [FromQuery]
        public string[] Name { get; set; } = null;

        [FromQuery]
        public string[] Path { get; set; } = null;

        protected override IQueryable<File> GetCustomQuery(IQueryable<File> query)
        {
            if (Name != null) query = query.Where(e => Name.Contains(e.Name));
            if (Path != null) query = query.Where(e => Path.Contains(e.Path));

            return query;
        }
    }
}
