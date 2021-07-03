using System;

namespace CopeID.API.Models
{
    public enum SpecimenGender
    {
        Male = 0,
        Female = 1
    }

    public class Specimen : Entity
    {
        public Guid GenusId { get; set; }
        public Genus Genus { get; set; }

        public Guid? PhotographId { get; set; }
        public Photograph Photograph { get; set; }

        public SpecimenGender Gender { get; set; }

        public float Length { get; set; }
    }
}
