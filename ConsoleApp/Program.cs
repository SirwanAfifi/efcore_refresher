using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        private static SaumraiContext context = new SaumraiContext();

        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            /*GetSamuraies("Before Add:");
            InsertMultipleSamuraies();
            GetSamuraies("After Add:");
            InsertNewSamuraiWithAQuote();
            */
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
            // var samuraies = context.Samuraies.ToList();
            // Console.WriteLine($"{text}: Samurai count is {samuraies.Count}");
            // foreach (var samuraie in samuraies)
            // {
            //     Console.WriteLine(samuraie.Name);
            // }

            var samuraies = context.Samuraies.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();
        }

        private static void InsertNewSamuraiWithAQuote()
        {
            var samurai = new Samurai
            {
                Name = "Kambei Shimada",
                Quotes = new List<Quote>
                {
                    new Quote { Text = "I've come to save you" }
                }
            };
            context.Samuraies.Add(samurai);
            context.SaveChanges();
        }

        #region Methods to Load related data
        private static void EagerLoadSamuraiWithQuotes()
        {
            var samuraiWithQuotes = context.Samuraies.Include(s => s.Quotes).ToList();
        }
        private static void ProjectSomeProperties()
        {
            var someProperties = context.Samuraies.Select(s => new { s.Id, s.Name }).ToList();
        }
        private static void ProjectSomePropertiesWithQuotes()
        {
            var somePropertiesWithQuotes = context.Samuraies.Select(s => new { s.Id, s.Name, s.Quotes.Count }).ToList();
        }
        private static void ExplicitLoadQuotes()
        {
            var samurai = context.Samuraies.FirstOrDefault(s => s.Name.Contains("Sirwan"));
            context.Entry(samurai).Collection(s => s.Quotes).Load();
            context.Entry(samurai).Reference(s => s.Horse).Load();
        }
        private static void LazyLoadQuotes()
        {
            var samurai = context.Samuraies.FirstOrDefault(s => s.Name.Contains("Sirwan"));

            var quoteCount = samurai.Quotes.Count();
        }

        #endregion

        #region Filtering
        private static void FilteringWihtRelatedData()
        {
            var samurais = context.Samuraies
                .Where(s => s.Quotes.Any(q => q.Text.Contains("happy")))
                .ToList();
        }
        #endregion
    }
}
