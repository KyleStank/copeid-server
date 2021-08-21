using System;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models;

namespace CopeID.API.QueryModels
{
    public class SpecimenQueryModel : EntityQueryModel
    {
        [FromQuery]
        public Guid GenusId { get; set; }

        [FromQuery]
        public Guid? PhotographId { get; set; }

        [FromQuery]
        public SpecimenGender Gender { get; set; }

        [FromQuery]
        public float Length { get; set; }
    }
}
