using System;
using System.Collections.Generic;

using CopeID.Models.Photographs;
using CopeID.Models.Specimens;

namespace CopeID.Models.Genuses
{
    public class Genus : Entity
    {
        public Guid? PhotographId { get; set; }
        public virtual Photograph Photograph { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Specimen> Specimens { get; set; }
    }
}
