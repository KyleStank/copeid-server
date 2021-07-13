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
    }
}
