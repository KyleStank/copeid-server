/**
 * TODO: Refactor seeding classes and add a priority to each Entity type.
 * Specimens require two foreign keys. One of those keys are generated in another seeder.
 * We need to ensure that other seeder runs first/before this one.
 */
//using System;
//using System.Threading.Tasks;

//using Microsoft.EntityFrameworkCore;

//using Newtonsoft.Json;

//using CopeID.Context;
//using CopeID.Models.Specimens;

//namespace CopeID.Seeding.Seeders
//{
//    public class SpecimenSeeder : ISeeder
//    {
//        private readonly CopeIdDbContext _context;
//        private readonly DbSet<Specimen> _set;

//        public SpecimenSeeder(CopeIdDbContext context)
//        {
//            _context = context;
//            _set = _context.Set<Specimen>();
//        }

//        public async Task Seed(string jsonContents)
//        {
//            Specimen[] models = JsonConvert.DeserializeObject<Specimen[]>(jsonContents);
//            if ((await _set.CountAsync()) == 0)
//            {
//                Console.WriteLine("Seeding Specimens...");
//                await _set.AddRangeAsync(models);
//            }
//            else
//            {
//                Console.WriteLine("Specimens already seeded");
//            }
//        }
//    }
//}
