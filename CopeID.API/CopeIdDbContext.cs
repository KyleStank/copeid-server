using Microsoft.EntityFrameworkCore;

using CopeID.API.Models;

namespace CopeID.API
{
    public class CopeIdDbContext : DbContext
    {
        public DbSet<Genus> Genuses { get; set; }

        public DbSet<Photograph> Photographs { get; set; }

        public DbSet<Specimen> Specimens { get; set; }

        public CopeIdDbContext(DbContextOptions<CopeIdDbContext> options) : base(options) { }
    }
}
