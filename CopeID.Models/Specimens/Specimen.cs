using System;

using CopeID.Models.Genuses;
using CopeID.Models.Photographs;

namespace CopeID.Models.Specimens
{
    public class Specimen : Entity
    {
        #region Basic Information

        public Guid GenusId { get; set; }
        public virtual Genus Genus { get; set; }

        public Guid? PhotographId { get; set; }
        public virtual Photograph Photograph { get; set; }

        public SpecimenGender Gender { get; set; }

        public float Length { get; set; }

        public string Summary { get; set; }

        public string SpecialCharacteristics { get; set; }

        #endregion

        #region Antenule

        public string AntenuleDescription { get; set; }

        public string Antenule { get; set; }

        #endregion

        #region Rostrum

        public string RostrumDescription { get; set; }

        public string Rostrum { get; set; }

        #endregion

        #region Body Shape

        public string BodyShapeDescription { get; set; }

        public string BodyShape { get; set; }

        #endregion

        #region Eyes

        public string EyesDescription { get; set; }

        public SpecimenEyes? Eyes { get; set; }

        #endregion

        #region Cephalosome

        public string CephalosomeDescription { get; set; }

        public int? Cephalosome { get; set; }

        #endregion

        #region Thorax

        public string ThoraxDescription { get; set; }

        public SpecimenThoraxSegments? ThoraxSegments { get; set; }

        public SpecimenThoraxShape? ThoraxShape { get; set; }

        #endregion

        #region Urosome

        public string UrosomeDescription { get; set; }

        public int? Urosome { get; set; }

        #endregion

        #region Furca

        public string FurcaDescription { get; set; }

        public SpecimenFurca? Furca { get; set; }

        #endregion

        #region Setea

        public string SeteaDescription { get; set; }

        public SpecimenSetea? Setea { get; set; }

        #endregion
    }
}
