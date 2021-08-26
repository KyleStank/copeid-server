﻿using Microsoft.EntityFrameworkCore;

using CopeID.Models.Contributors;
using CopeID.Models.Definitions;
using CopeID.Models.Filters;
using CopeID.Models.Genuses;
using CopeID.Models.Photographs;
using CopeID.Models.References;
using CopeID.Models.Specimens;

namespace CopeID.Context
{
    public class CopeIdDbContext : DbContext
    {
        public DbSet<Contributor> Contributors { get; set; }

        public DbSet<Definition> Definitions { get; set; }

        public DbSet<FilterModel> FilterModels { get; set; }

        public DbSet<FilterModelProperty> FilterModelProperties { get; set; }

        public DbSet<Filter> Filters { get; set; }

        public DbSet<FilterSection> FilterSections { get; set; }

        public DbSet<FilterSectionOption> FilterSectionOptions { get; set; }

        public DbSet<Genus> Genuses { get; set; }

        public DbSet<Photograph> Photographs { get; set; }

        public DbSet<Reference> References { get; set; }

        public DbSet<Specimen> Specimens { get; set; }

        public CopeIdDbContext(DbContextOptions<CopeIdDbContext> options) : base(options) { }
    }
}
