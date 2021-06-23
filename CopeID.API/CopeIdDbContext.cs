using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using CopeID.API.Models;

namespace CopeID.API
{
    public class CopeIdDbContext : DbContext
    {
        public DbSet<Copepod> Copepods { get; set; }

        public CopeIdDbContext(DbContextOptions<CopeIdDbContext> options) : base(options)
        { }
    }
}
