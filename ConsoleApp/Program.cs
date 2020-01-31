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
            InsertMultipleSamuraies();
            GetSamuraies("After Add:");
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void InsertMultipleSamuraies()
        {
            var samuraie = new Samurai { Name = "Sirwan" };
            var samuraie2 = new Samurai { Name = "Sana" };

            context.Samuraies.AddRange(samuraie, samuraie2);
            context.SaveChanges();
        }

        private static void AddSamuraie()
        {
            var samuraie = new Samurai { Name = "Sirwan" };
            context.Samuraies.Add(samuraie);
            context.SaveChanges();
        }

        private static void GetSamuraies(string text)
        {
            var samuraies = context.Samuraies.ToList();
            Console.WriteLine($"{text}: Samurai count is {samuraies.Count}");
            foreach (var samuraie in samuraies)
            {
                Console.WriteLine(samuraie.Name);
            }
        }
    }
}
