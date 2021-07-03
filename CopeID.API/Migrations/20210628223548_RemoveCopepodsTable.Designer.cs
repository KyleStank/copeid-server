﻿// <auto-generated />
using System;
using CopeID.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CopeID.API.Migrations
{
    [DbContext(typeof(CopeIdDbContext))]
    [Migration("20210628223548_RemoveCopepodsTable")]
    partial class RemoveCopepodsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CopeID.API.Models.Genus", b =>
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

            modelBuilder.Entity("CopeID.API.Models.Photograph", b =>
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

            modelBuilder.Entity("CopeID.API.Models.Specimen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid>("GenusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<Guid?>("PhotographId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GenusId");

                    b.HasIndex("PhotographId");

                    b.ToTable("Specimens");
                });

            modelBuilder.Entity("CopeID.API.Models.Genus", b =>
                {
                    b.HasOne("CopeID.API.Models.Photograph", "Photograph")
                        .WithMany()
                        .HasForeignKey("PhotographId");

                    b.Navigation("Photograph");
                });

            modelBuilder.Entity("CopeID.API.Models.Specimen", b =>
                {
                    b.HasOne("CopeID.API.Models.Genus", "Genus")
                        .WithMany("Specimens")
                        .HasForeignKey("GenusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CopeID.API.Models.Photograph", "Photograph")
                        .WithMany()
                        .HasForeignKey("PhotographId");

                    b.Navigation("Genus");

                    b.Navigation("Photograph");
                });

            modelBuilder.Entity("CopeID.API.Models.Genus", b =>
                {
                    b.Navigation("Specimens");
                });
#pragma warning restore 612, 618
        }
    }
}
