using Microsoft.AspNetCore.Mvc;

namespace CopeID.API.QueryModels
{
    public class DefinitionQueryModel : EntityQueryModel
    {
        [FromQuery]
        public string Name { get; set; }

        [FromQuery]
        public string Meaning { get; set; }
    }
}
