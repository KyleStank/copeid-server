using Microsoft.AspNetCore.Mvc;

namespace CopeID.API.QueryModels
{
    public class ReferenceQueryModel : EntityQueryModel
    {
        [FromQuery]
        public string Content { get; set; }
    }
}
