using System;

using Microsoft.EntityFrameworkCore;

using CopeID;

namespace CopeID.Seeding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new DbContext())
            {
                Console.WriteLine("Connected!");
            }
        }
    }
}
