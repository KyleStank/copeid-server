using Microsoft.AspNetCore.Mvc;

namespace CopeID.API.QueryModels
{
    public class ContributorQueryModel : EntityQueryModel
    {
        [FromQuery]
        public string Name { get; set; }
    }
}
