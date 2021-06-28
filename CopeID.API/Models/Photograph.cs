using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopeID.API.Models
{
    public class Photograph : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Alt { get; set; }

        public string Url { get; set; }
    }
}
