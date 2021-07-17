using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using CopeID.Context;
using CopeID.Models;

namespace CopeID.Seeding
{
    class Program
    {
        private static readonly string _jsonDataDirectory = "Data/";

        private static readonly string _photographDataFile = _jsonDataDirectory + "PhotographData.json";
        private static readonly string _genusDataFile = _jsonDataDirectory + "GenusData.json";
        private static readonly string _specimenDataFile = _jsonDataDirectory + "SpecimenData.json";
        private static readonly string _contributorsDataFile = _jsonDataDirectory + "ContributorsData.json";
        private static readonly string _definitionsDataFile = _jsonDataDirectory + "DefinitionsData.json";

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Seed Database ===");
            Console.WriteLine("Reading seeding data...");
            Console.WriteLine("\n");

            // Read JSON data.
            string photographJson = await ReadTextFile(_photographDataFile);
            Photograph[] photographData = JsonConvert.DeserializeObject<Photograph[]>(photographJson);

            string genusJson = await ReadTextFile(_genusDataFile);
            Genus[] genusData = JsonConvert.DeserializeObject<Genus[]>(genusJson);
            for (int i = 0; i < genusData.Length; i++)
            {
                Random rand = new Random();

                Photograph photo = photographData[rand.Next(0, photographData.Length)];

                genusData[i].PhotographId = photo.Id;
            }

            string specimenJson = await ReadTextFile(_specimenDataFile);
            Specimen[] specimenData = JsonConvert.DeserializeObject<Specimen[]>(specimenJson);
            for (int i = 0; i < specimenData.Length; i++)
            {
                Random rand = new Random();

                Genus genus = genusData[rand.Next(0, genusData.Length)];
                Photograph photo = photographData[rand.Next(0, photographData.Length)];

                specimenData[i].GenusId = genus.Id;
                specimenData[i].PhotographId = photo.Id;
            }

            string contributorsJson = await ReadTextFile(_contributorsDataFile);
            Contributor[] contributorsData = JsonConvert.DeserializeObject<Contributor[]>(contributorsJson);

            string definitionsJson = await ReadTextFile(_definitionsDataFile);
            Definition[] definitionsData = JsonConvert.DeserializeObject<Definition[]>(definitionsJson);

            Console.WriteLine("Creating DB Context...");

            // Connect to DB.
            DbContextOptions<CopeIdDbContext> options = new DbContextOptionsBuilder<CopeIdDbContext>()
                .UseSqlServer("Server=localhost;Database=CopeId;User=sa;Password=Edison15;")
                .Options;

            using (CopeIdDbContext context = new CopeIdDbContext(options))
            {
                context.Database.EnsureCreated();
                Console.WriteLine("DB context created!");
                Console.WriteLine("\n");
                Console.WriteLine("Begin seeding...");

                DbSet<Photograph> photographSet = context.Set<Photograph>();
                if (photographSet.Count() == 0)
                {
                    Console.WriteLine("- Seeding Photographs...");
                    await photographSet.AddRangeAsync(photographData);
                }
                else
                {
                    Console.WriteLine("- Photographs already seeded");
                }

                DbSet<Genus> genusSet = context.Set<Genus>();
                if (genusSet.Count() == 0) 
                {
                    Console.WriteLine("- Seeding Genuses...");
                    await genusSet.AddRangeAsync(genusData);
                }
                else
                {
                    Console.WriteLine("- Genuses already seeded");
                }

                DbSet<Specimen> specimenSet = context.Set<Specimen>();
                if (specimenSet.Count() == 0)
                {
                    Console.WriteLine("- Seeding Specimens...");
                    await specimenSet.AddRangeAsync(specimenData);
                }
                else
                {
                    Console.WriteLine("- Specimens already seeded");
                }

                DbSet<Contributor> contributorSet = context.Set<Contributor>();
                if (contributorSet.Count() == 0)
                {
                    Console.WriteLine("- Seeding Contributors...");
                    await contributorSet.AddRangeAsync(contributorsData);
                }
                else
                {
                    Console.WriteLine("- Contributors already seeded");
                }

                DbSet<Definition> definitionSet = context.Set<Definition>();
                if (definitionSet.Count() == 0)
                {
                    Console.WriteLine("- Seeding Definitions...");
                    await definitionSet.AddRangeAsync(definitionsData);
                }
                else
                {
                    Console.WriteLine("- Definitions already seeded");
                }

                Console.WriteLine("Saving DB...");

                context.SaveChanges();
            }

            Console.WriteLine("\n");
            Console.WriteLine("=== Completed seeding ===");
        }

        static async Task<string> ReadTextFile(string file)
        {
            string contents = "";
            using (StreamReader r = new StreamReader(file))
                contents += await r.ReadToEndAsync();
            return contents;
        }
    }
}
