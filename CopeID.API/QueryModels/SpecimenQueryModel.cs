using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models;

namespace CopeID.API.QueryModels
{
    public class SpecimenQueryModel : EntityQueryModel<Specimen>
    {
        [FromQuery]
        public Guid[] GenusId { get; set; } = null;

        [FromQuery]
        public Guid?[] PhotographId { get; set; } = null;

        [FromQuery]
        public SpecimenGender[] Gender { get; set; } = null;

        [FromQuery]
        public float[] Length { get; set; } = null;

        protected override IQueryable<Specimen> GetCustomQuery(IQueryable<Specimen> query)
        {
            if (GenusId != null) query = query.Where(e => GenusId.Contains(e.GenusId));
            if (PhotographId != null) query = query.Where(e => PhotographId.Contains(e.PhotographId));
            if (Gender != null) query = query.Where(e => Gender.Contains(e.Gender));
            if (Length != null) query = query.Where(e => Length.Contains(e.Length));

            return query;
        }
    }
}
