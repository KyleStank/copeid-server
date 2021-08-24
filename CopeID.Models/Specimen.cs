using System;

namespace CopeID.Models
{
    public enum SpecimenGender
    {
        Male = 0,
        Female = 1
    }

    public class Specimen : Entity
    {
        public Guid GenusId { get; set; }
        public virtual Genus Genus { get; set; }

        public Guid? PhotographId { get; set; }
        public virtual Photograph Photograph { get; set; }

        public SpecimenGender Gender { get; set; }

        public float Length { get; set; }

        public string SpecialCharacteristics { get; set; }

        public string Antenule { get; set; }

        public string Rostrum { get; set; }

        public string BodyShape { get; set; }

        public string Eyes { get; set; }

        public string Cephalosome { get; set; }

        public string Thorax { get; set; }

        public string Urosome { get; set; }

        public string Furca { get; set; }

        public string Setea { get; set; }
    }
}
