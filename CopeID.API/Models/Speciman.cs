using System;

namespace CopeID.API.Models
{
    public enum SpecimanGender
    {
        Male = 0,
        Female = 1
    }

    public class Speciman
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid GenusId { get; set; }
        public Genus Genus { get; set; }

        public Guid? PhotographId { get; set; }
        public Photograph Photograph { get; set; }

        public SpecimanGender Gender { get; set; }

        public float Length { get; set; }
    }
}
