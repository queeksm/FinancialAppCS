using System;

using FinanceApp.Infrastructure.Data.Context;

namespace FinanceApp.Infrastructure.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Database");
            ClientContext db = new ClientContext();
            db.Database.EnsureCreated();
            Console.WriteLine("Created");
            Console.ReadKey();
        }
    }
}
