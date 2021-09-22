using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using CopeID.Context;
using CopeID.Models.Genuses;

namespace CopeID.Seeding.Seeders
{
    public class GenusSeeder : ISeeder
    {
        private readonly CopeIdDbContext _context;
        private readonly DbSet<Genus> _set;

        public GenusSeeder(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<Genus>();
        }

        public async Task Seed(string jsonContents)
        {
            Genus[] models = JsonConvert.DeserializeObject<Genus[]>(jsonContents);
            if ((await _set.CountAsync()) == 0)
            {
                Console.WriteLine("Seeding Genuses...");
                await _set.AddRangeAsync(models);
            }
            else
            {
                Console.WriteLine("Genuses already seeded");
            }
        }
    }
}
