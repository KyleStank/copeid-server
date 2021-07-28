using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using CopeID.Context;
using CopeID.Models;

namespace CopeID.Seeding.Seeders
{
    public class PhotographSeeder : ISeeder
    {
        private readonly CopeIdDbContext _context;
        private readonly DbSet<Photograph> _set;

        public PhotographSeeder(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<Photograph>();
        }

        public async Task Seed(string jsonContents)
        {
            Photograph[] models = JsonConvert.DeserializeObject<Photograph[]>(jsonContents);
            if ((await _set.CountAsync()) == 0)
            {
                Console.WriteLine("Seeding Photographs...");
                await _set.AddRangeAsync(models);
            }
            else
            {
                Console.WriteLine("Photographs already seeded");
            }
        }
    }
}
