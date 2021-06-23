using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CopeID.API.Models
{
    public class Copepod
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Genus { get; set; }
    }
}
