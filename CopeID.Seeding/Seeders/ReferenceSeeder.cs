using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using CopeID.Context;
using CopeID.Models;

namespace CopeID.Seeding.Seeders
{
    public class ReferenceSeeder : ISeeder
    {
        private readonly CopeIdDbContext _context;
        private readonly DbSet<Reference> _set;

        public ReferenceSeeder(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<Reference>();
        }

        public async Task Seed(string jsonContents)
        {
            Reference[] models = JsonConvert.DeserializeObject<Reference[]>(jsonContents);
            if ((await _set.CountAsync()) == 0)
            {
                Console.WriteLine("Seeding References...");
                await _set.AddRangeAsync(models);
            }
            else
            {
                Console.WriteLine("References already seeded");
            }
        }
    }
}
