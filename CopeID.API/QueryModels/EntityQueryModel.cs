using System;

using Microsoft.AspNetCore.Mvc;

namespace CopeID.API.QueryModels
{
    public abstract class EntityQueryModel
    {
        [FromQuery]
        public Guid[] Ids { get; set; } = null;

        [FromQuery]
        public string[] Include { get; set; } = null;

        [FromQuery]
        public string[] OrderBy { get; set; } = null;

        [FromQuery]
        public string[] OrderByDescending { get; set; } = null;
    }
}
