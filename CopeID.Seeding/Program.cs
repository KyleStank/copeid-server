using System.Threading.Tasks;

namespace CopeID.Seeding
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Seeder seeder = new Seeder();
            await seeder.Seed();
        }
    }
}
