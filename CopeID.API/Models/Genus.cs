using System;
using System.Collections.Generic;

namespace CopeID.API.Models
{
    public class Genus : Entity
    {
        public Guid? PhotographId { get; set; }
        public Photograph Photograph { get; set; }

        public string Name { get; set; }

        public ICollection<Speciman> Specimens { get; set; }
    }
}
