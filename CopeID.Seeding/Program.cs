using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using CopeID.API;
using CopeID.API.Models;

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
            using (StreamReader reader = new StreamReader(_photographDataFile))
            {
                string json = await  reader.ReadToEndAsync();
            }

            //var options = new DbContextOptionsBuilder<CopeIdDbContext>()
            //    .UseSqlServer("Server=localhost;Database=CopeId;User=sa;Password=Edison15;")
            //    .Options;

            //using (var context = new CopeIdDbContext(options))
            //{
            //    context.Database.EnsureCreated();

            //    var genuses = context.Set<Genus>().ToList();
            //    var photographs = context.Set<Photograph>().ToList();
            //    var specimens = context.Set<Specimen>().ToList();

            //    context.SaveChanges();
            //}
        }
    }
}
