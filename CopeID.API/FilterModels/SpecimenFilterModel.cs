using System;

using CopeID.Models.Specimens;

namespace CopeID.API.FilterModels
{
    public class SpecimenFilterModel : Specimen, IFilterModel
    {
        public new Guid? Id { get; set; }

        public new Guid? GenusId { get; set; }

        public new SpecimenGender? Gender { get; set; }

        public new float? Length { get; set; }
    }
}
