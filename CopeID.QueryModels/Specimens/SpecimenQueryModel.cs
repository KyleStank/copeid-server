using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using CopeID.Models.Specimens;

namespace CopeID.QueryModels.Specimens
{
    public class SpecimenQueryModel : EntityQueryModel<Specimen>
    {
        #region Basic Information

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

        #endregion

        #region Antenule

        [FromQuery]
        public string[] AntenuleDescription { get; set; } = null;

        [FromQuery]
        public string[] Antenule { get; set; } = null;

        #endregion

        #region Rostrum

        [FromQuery]
        public string[] RostrumDescription { get; set; } = null;

        [FromQuery]
        public string[] Rostrum { get; set; } = null;

        #endregion

        #region Body Shape

        [FromQuery]
        public string[] BodyShapeDescription { get; set; } = null;

        [FromQuery]
        public string[] BodyShape { get; set; } = null;

        #endregion

        #region Eyes

        [FromQuery]
        public string[] EyesDescription { get; set; } = null;

        [FromQuery]
        public SpecimenEyes?[] Eyes { get; set; } = null;

        #endregion

        #region Cephalosome

        [FromQuery]
        public string[] CephalosomeDescription { get; set; } = null;

        [FromQuery]
        public int?[] Cephalosome { get; set; } = null;

        #endregion

        #region Thorax

        [FromQuery]
        public string[] ThoraxDescription { get; set; } = null;

        [FromQuery]
        public SpecimenThoraxSegments?[] ThoraxSegments { get; set; } = null;

        [FromQuery]
        public SpecimenThoraxShape?[] ThoraxShape { get; set; } = null;

        #endregion

        #region Urosome

        [FromQuery]
        public string[] UrosomeDescription { get; set; } = null;

        [FromQuery]
        public int?[] Urosome { get; set; } = null;

        #endregion

        #region Furca

        [FromQuery]
        public string[] FurcaDescription { get; set; } = null;

        [FromQuery]
        public SpecimenFurca?[] Furca { get; set; } = null;

        #endregion

        #region Setea

        [FromQuery]
        public string[] SeteaDescription { get; set; } = null;

        [FromQuery]
        public SpecimenSetea?[] Setea { get; set; } = null;

        #endregion

        protected override IQueryable<Specimen> GetCustomQuery(IQueryable<Specimen> query)
        {
            // Basic Information
            if (GenusId != null) query = query.Where(e => GenusId.Contains(e.GenusId));
            if (PhotographId != null) query = query.Where(e => PhotographId.Contains(e.PhotographId));
            if (Gender != null) query = query.Where(e => Gender.Contains(e.Gender));
            if (Length != null) query = query.Where(e => Length.Contains(e.Length));
            if (SpecialCharacteristics != null) query = query.Where(e => SpecialCharacteristics.Contains(e.SpecialCharacteristics));

            // Antenule
            if (AntenuleDescription != null) query = query.Where(e => AntenuleDescription.Contains(e.AntenuleDescription));
            if (Antenule != null) query = query.Where(e => Antenule.Contains(e.Antenule));

            // Rostrum
            if (RostrumDescription != null) query = query.Where(e => RostrumDescription.Contains(e.RostrumDescription));
            if (Rostrum != null) query = query.Where(e => Rostrum.Contains(e.Rostrum));

            // Body Shape
            if (BodyShapeDescription != null) query = query.Where(e => BodyShapeDescription.Contains(e.BodyShapeDescription));
            if (BodyShape != null) query = query.Where(e => BodyShape.Contains(e.BodyShape));

            // Eyes
            if (EyesDescription != null) query = query.Where(e => EyesDescription.Contains(e.EyesDescription));
            if (Eyes != null) query = query.Where(e => Eyes.Contains(e.Eyes));

            // Cephalosome
            if (CephalosomeDescription != null) query = query.Where(e => CephalosomeDescription.Contains(e.CephalosomeDescription));
            if (Cephalosome != null) query = query.Where(e => Cephalosome.Contains(e.Cephalosome));

            // Thorax
            if (ThoraxDescription != null) query = query.Where(e => ThoraxDescription.Contains(e.ThoraxDescription));
            if (ThoraxSegments != null) query = query.Where(e => ThoraxSegments.Contains(e.ThoraxSegments));
            if (ThoraxShape != null) query = query.Where(e => ThoraxShape.Contains(e.ThoraxShape));

            // Urosome
            if (UrosomeDescription != null) query = query.Where(e => UrosomeDescription.Contains(e.UrosomeDescription));
            if (Urosome != null) query = query.Where(e => Urosome.Contains(e.Urosome));

            // Furca
            if (FurcaDescription != null) query = query.Where(e => FurcaDescription.Contains(e.FurcaDescription));
            if (Furca != null) query = query.Where(e => Furca.Contains(e.Furca));

            // Setea
            if (SeteaDescription != null) query = query.Where(e => SeteaDescription.Contains(e.SeteaDescription));
            if (Setea != null) query = query.Where(e => Setea.Contains(e.Setea));

            return query;
        }
    }
}
