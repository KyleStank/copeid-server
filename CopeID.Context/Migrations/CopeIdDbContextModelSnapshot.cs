﻿// <auto-generated />
using System;
using CopeID.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CopeID.Context.Migrations
{
    [DbContext(typeof(CopeIdDbContext))]
    partial class CopeIdDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CopeID.Models.Contributors.Contributor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("CopeID.Models.Definitions.Definition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Meaning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Definitions");
                });

            modelBuilder.Entity("CopeID.Models.Documents.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("CopeID.Models.Filters.Filter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FilterModelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FilterModelId");

                    b.ToTable("Filters");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FilterModels");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterModelProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilterModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilterModelId");

                    b.ToTable("FilterModelProperties");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FilterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilterId");

                    b.ToTable("FilterSections");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterSectionPart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FilterModelPropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilterSectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilterModelPropertyId");

                    b.HasIndex("FilterSectionId");

                    b.ToTable("FilterSectionParts");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterSectionPartOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FilterSectionPartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilterSectionPartId");

                    b.ToTable("FilterSectionPartOptions");
                });

            modelBuilder.Entity("CopeID.Models.Genuses.Genus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PhotographId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PhotographId");

                    b.ToTable("Genuses");
                });

            modelBuilder.Entity("CopeID.Models.Photographs.Photograph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photographs");
                });

            modelBuilder.Entity("CopeID.Models.References.Reference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("References");
                });

            modelBuilder.Entity("CopeID.Models.Specimens.Specimen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Antenule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AntenuleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BodyShape")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BodyShapeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Cephalosome")
                        .HasColumnType("int");

                    b.Property<string>("CephalosomeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Eyes")
                        .HasColumnType("int");

                    b.Property<string>("EyesDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Furca")
                        .HasColumnType("int");

                    b.Property<string>("FurcaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid>("GenusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<Guid?>("PhotographId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Rostrum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RostrumDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Setea")
                        .HasColumnType("int");

                    b.Property<string>("SeteaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialCharacteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThoraxDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThoraxSegments")
                        .HasColumnType("int");

                    b.Property<int?>("ThoraxShape")
                        .HasColumnType("int");

                    b.Property<int?>("Urosome")
                        .HasColumnType("int");

                    b.Property<string>("UrosomeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenusId");

                    b.HasIndex("PhotographId");

                    b.ToTable("Specimens");
                });

            modelBuilder.Entity("CopeID.Models.Filters.Filter", b =>
                {
                    b.HasOne("CopeID.Models.Filters.FilterModel", "FilterModel")
                        .WithMany("Filters")
                        .HasForeignKey("FilterModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilterModel");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterModelProperty", b =>
                {
                    b.HasOne("CopeID.Models.Filters.FilterModel", "FilterModel")
                        .WithMany("FilterModelProperties")
                        .HasForeignKey("FilterModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilterModel");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterSection", b =>
                {
                    b.HasOne("CopeID.Models.Filters.Filter", "Filter")
                        .WithMany("FilterSections")
                        .HasForeignKey("FilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filter");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterSectionPart", b =>
                {
                    b.HasOne("CopeID.Models.Filters.FilterModelProperty", "FilterModelProperty")
                        .WithMany()
                        .HasForeignKey("FilterModelPropertyId");

                    b.HasOne("CopeID.Models.Filters.FilterSection", "FilterSection")
                        .WithMany("FilterSectionParts")
                        .HasForeignKey("FilterSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilterModelProperty");

                    b.Navigation("FilterSection");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterSectionPartOption", b =>
                {
                    b.HasOne("CopeID.Models.Filters.FilterSectionPart", "FilterSectionPart")
                        .WithMany("FilterSectionPartOptions")
                        .HasForeignKey("FilterSectionPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilterSectionPart");
                });

            modelBuilder.Entity("CopeID.Models.Genuses.Genus", b =>
                {
                    b.HasOne("CopeID.Models.Photographs.Photograph", "Photograph")
                        .WithMany()
                        .HasForeignKey("PhotographId");

                    b.Navigation("Photograph");
                });

            modelBuilder.Entity("CopeID.Models.Specimens.Specimen", b =>
                {
                    b.HasOne("CopeID.Models.Genuses.Genus", "Genus")
                        .WithMany("Specimens")
                        .HasForeignKey("GenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopeID.Models.Photographs.Photograph", "Photograph")
                        .WithMany()
                        .HasForeignKey("PhotographId");

                    b.Navigation("Genus");

                    b.Navigation("Photograph");
                });

            modelBuilder.Entity("CopeID.Models.Filters.Filter", b =>
                {
                    b.Navigation("FilterSections");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterModel", b =>
                {
                    b.Navigation("FilterModelProperties");

                    b.Navigation("Filters");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterSection", b =>
                {
                    b.Navigation("FilterSectionParts");
                });

            modelBuilder.Entity("CopeID.Models.Filters.FilterSectionPart", b =>
                {
                    b.Navigation("FilterSectionPartOptions");
                });

            modelBuilder.Entity("CopeID.Models.Genuses.Genus", b =>
                {
                    b.Navigation("Specimens");
                });
#pragma warning restore 612, 618
        }
    }
}
