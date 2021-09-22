using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using CopeID.Context;
using CopeID.Models.Definitions;

namespace CopeID.Seeding.Seeders
{
    public class DefinitionSeeder : ISeeder
    {
        private readonly CopeIdDbContext _context;
        private readonly DbSet<Definition> _set;

        public DefinitionSeeder(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<Definition>();
        }

        public async Task Seed(string jsonContents)
        {
            Definition[] models = JsonConvert.DeserializeObject<Definition[]>(jsonContents);
            if ((await _set.CountAsync()) == 0)
            {
                Console.WriteLine("Seeding Definitions...");
                await _set.AddRangeAsync(models);
            }
            else
            {
                Console.WriteLine("Definitions already seeded");
            }
        }
    }
}
