using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopeID.API.Models
{
    public class Genus
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? PhotographId { get; set; }
        public Photograph Photograph { get; set; }

        public string Name { get; set; }

        public ICollection<Speciman> Specimens { get; set; }
    }
}
