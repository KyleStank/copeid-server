using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

using Microsoft.EntityFrameworkCore;

using CopeID.Context;
using CopeID.Models;

namespace CopeID.Seeding
{
    public interface ISeeder
    {
        Task Seed(string jsonContents);
    }

    public class Seeder
    {
        private static readonly string _dataDirectory = "Data/";
        private static readonly string _dataExtension = "json";

        private static IEnumerable<Type> GetAssemblyTypes<T>(Func<Type, bool> predicate = null)
        {
            return Assembly.GetAssembly(typeof(T)).GetTypes().Where(t => predicate == null || predicate.Invoke(t)).AsEnumerable();
        }

        private static IEnumerable<Type> GetClassTypes<T>() where T : class
        {
            return GetAssemblyTypes<T>().Where(t => !t.IsAbstract && t.IsClass && t.IsSubclassOf(typeof(T)));
        }

        private static IEnumerable<Type> GetInterfaceTypes<T>()
        {
            return GetAssemblyTypes<T>().Where(t => !t.IsAbstract && t.IsClass && t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(T)));
        }

        public async Task Seed(CopeIdDbContext context, string dataPath = null)
        {
            Console.WriteLine("===== BEGIN SEEDING =====");
            Console.WriteLine("\n");

            // Connect to DB.
            Console.WriteLine("=== Initialize ===");
            Console.WriteLine("== Connection ==");
            Console.WriteLine("Connecting to SQL server...");

            Console.WriteLine("Connected to SQL server.");
            Console.WriteLine("\n");

            // Run migrations.
            Console.WriteLine("== Migrations ==");
            if ((await context.Database.GetPendingMigrationsAsync()).Count() > 0)
            {
                Console.WriteLine("Applying migrations...");
                await context.Database.MigrateAsync();
                Console.WriteLine("Migrations applied.");
            }
            else
            {
                Console.WriteLine("No migrations to apply");
            }
            Console.WriteLine("\n");

            // Start seeding.
            Console.WriteLine("=== Seeding ===");
            Console.WriteLine("Finding all seeders...");
            IEnumerable<Type> seederTypes = GetInterfaceTypes<ISeeder>();

            Console.WriteLine("Finding all models...");
            IEnumerable<Type> entityTypes = GetClassTypes<Entity>();
            Console.WriteLine("\n");
            foreach (string entityType in entityTypes.Select(t => t.Name))
            {
                Console.WriteLine($"== {entityType} ==");
                Type seederType = seederTypes.FirstOrDefault(t => t.Name.Contains(entityType));
                if (seederType != null)
                {
                    Console.WriteLine($"Found seeder [{seederType.Name}] for Entity [{entityType}]");

                    string path = $"{Path.Combine(dataPath ?? _dataDirectory, entityType)}.{_dataExtension}";
                    Console.WriteLine($"Searching for {path}...");
                    if (File.Exists(path))
                    {
                        Console.WriteLine($"{path} found! Creating instance of seeder [{seederType.Name}]...");
                        ISeeder seederInstance = Activator.CreateInstance(seederType, context) as ISeeder;
                        Console.WriteLine("Instance created, seeding...");
                        await seederInstance.Seed(File.ReadAllText(path));
                        Console.WriteLine($"Seeding completed for Entity [{entityType}]");
                    }
                    else
                    {
                        Console.WriteLine($"{path} not found! Skipping seeding for Entity [{entityType}]...");
                    }
                }
                else
                {
                    Console.WriteLine($"No seeder exists for Entity [{entityType}], skipping...");
                }

                Console.WriteLine("\n");
            }

            // Save changes.
            Console.WriteLine("=== Finalize ===");
            Console.WriteLine("Saving database changes...");
            await context.SaveChangesAsync();
            Console.WriteLine("Saved database changes!");

            Console.WriteLine("\n");
            Console.WriteLine("===== SEEDING COMPLETE =====");
        }
    }
}
