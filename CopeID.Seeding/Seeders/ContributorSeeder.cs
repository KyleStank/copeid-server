using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using CopeID.Context;
using CopeID.Models;

namespace CopeID.Seeding.Seeders
{
    public class ContributorSeeder : ISeeder
    {
        private readonly CopeIdDbContext _context;
        private readonly DbSet<Contributor> _set;

        public ContributorSeeder(CopeIdDbContext context)
        {
            _context = context;
            _set = _context.Set<Contributor>();
        }

        public async Task Seed(string jsonContents)
        {
            Contributor[] models = JsonConvert.DeserializeObject<Contributor[]>(jsonContents);
            if ((await _set.CountAsync()) == 0)
            {
                Console.WriteLine("Seeding Contributors...");
                await _set.AddRangeAsync(models);
            }
            else
            {
                Console.WriteLine("Contributors already seeded");
            }
        }
    }
}
