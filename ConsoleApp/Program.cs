using System;
using System.Linq;
using Data;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        private static SaumraiContext context = new SaumraiContext();

        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            GetSamuraies("Before Add:");
            AddSamuraie();
            GetSamuraies("After Add:");
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddSamuraie()
        {
            var samuraie = new Samurai { Name = "Sampson " };
            context.Samuraies.Add(samuraie);
            context.SaveChanges();
        }

        private static void GetSamuraies(string text)
        {
            var samuraies = context.Samuraies.ToList();
            Console.Write($"${text}: Samurai count is ${samuraies.Count}");
            foreach (var samuraie in samuraies)
            {
                Console.WriteLine(samuraie.Name);
            }
        }
    }
}
