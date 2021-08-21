using Microsoft.AspNetCore.Mvc;

namespace CopeID.API.QueryModels
{
    public class PhotographQueryModel : EntityQueryModel
    {
        [FromQuery]
        public string Title { get; set; }

        [FromQuery]
        public string Description { get; set; }

        [FromQuery]
        public string Alt { get; set; }

        [FromQuery]
        public string Url { get; set; }
    }
}
