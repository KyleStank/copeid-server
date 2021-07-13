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

        static async Task Main(string[] args)
        {
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

            // Connect to DB.
            DbContextOptions<CopeIdDbContext> options = new DbContextOptionsBuilder<CopeIdDbContext>()
                .UseSqlServer("Server=localhost;Database=CopeId;User=sa;Password=Edison15;")
                .Options;

            using (CopeIdDbContext context = new CopeIdDbContext(options))
            {
                context.Database.EnsureCreated();

                await context.Set<Photograph>().AddRangeAsync(photographData);
                await context.Set<Genus>().AddRangeAsync(genusData);
                await context.Set<Specimen>().AddRangeAsync(specimenData);

                context.SaveChanges();
            }
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
