using System;

using Microsoft.AspNetCore.Mvc;

namespace CopeID.API.QueryModels
{
    public class GenusQueryModel : EntityQueryModel
    {
        [FromQuery]
        public Guid? PhotographId { get; set; }

        [FromQuery]
        public string Name { get; set; }
    }
}
