using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Specimens;

namespace CopeID.API.QueryModels.Specimens
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

        [FromQuery]
        public string[] SpecialCharacteristics { get; set; } = null;

        [FromQuery]
        public string[] Antenule { get; set; } = null;

        [FromQuery]
        public string[] Rostrum { get; set; } = null;

        [FromQuery]
        public string[] BodyShape { get; set; } = null;

        [FromQuery]
        public string[] Eyes { get; set; } = null;

        [FromQuery]
        public string[] Cephalosome { get; set; } = null;

        [FromQuery]
        public string[] Thorax { get; set; } = null;

        [FromQuery]
        public string[] Urosome { get; set; } = null;

        [FromQuery]
        public string[] Furca { get; set; } = null;

        [FromQuery]
        public string[] Setea { get; set; } = null;

        protected override IQueryable<Specimen> GetCustomQuery(IQueryable<Specimen> query)
        {
            if (GenusId != null) query = query.Where(e => GenusId.Contains(e.GenusId));
            if (PhotographId != null) query = query.Where(e => PhotographId.Contains(e.PhotographId));
            if (Gender != null) query = query.Where(e => Gender.Contains(e.Gender));
            if (Length != null) query = query.Where(e => Length.Contains(e.Length));
            if (SpecialCharacteristics != null) query = query.Where(e => SpecialCharacteristics.Contains(e.SpecialCharacteristics));
            if (Antenule != null) query = query.Where(e => Antenule.Contains(e.Antenule));
            if (Rostrum != null) query = query.Where(e => Rostrum.Contains(e.Rostrum));
            if (BodyShape != null) query = query.Where(e => BodyShape.Contains(e.BodyShape));
            if (Eyes != null) query = query.Where(e => Eyes.Contains(e.Eyes));
            if (Cephalosome != null) query = query.Where(e => Cephalosome.Contains(e.Cephalosome));
            if (Thorax != null) query = query.Where(e => Thorax.Contains(e.Thorax));
            if (Urosome != null) query = query.Where(e => Urosome.Contains(e.Urosome));
            if (Furca != null) query = query.Where(e => Furca.Contains(e.Furca));
            if (Setea != null) query = query.Where(e => Setea.Contains(e.Setea));

            return query;
        }
    }
}
