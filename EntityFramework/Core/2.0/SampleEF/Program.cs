using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SampleEF.Domain;
using SampleEFCore.Data;

namespace SampleEF
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertSamurai();
            //insertMultipleSamurai();

            //SelectSamurais();


            //SelectFindByKey();

            //Like_New_Method_2_0();


            //LastOrDefaultProperWayOFUse();

            //UpdateEntityInDiscontinuedApproach();


            //DeleteEntity();


            //AddRelatedData();


            Console.WriteLine("saved");
        }

        private static void AddRelatedData()
        {
            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                var battle = new Battle()
                {
                    BattleName = "test",
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now
                };
                context.Battles.Add(battle);
                var samurai = context.Samurais.FirstOrDefault();
                if (samurai != null)
                {
                    var samuraibattles = new SamuraiBattle()
                    {
                        Samurai = samurai,
                        Battle = battle
                    };
                    context.Add(samuraibattles);
                }


                context.SaveChanges();
            }
        }

        private static void DeleteEntity()
        {
            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                var samurai = context.Samurais.FirstOrDefault();
                if (samurai != null)
                {
                    context.Samurais.Remove(samurai);
                    context.SaveChanges();
                }
            }
        }

        private static void UpdateEntityInDiscontinuedApproach()
        {
            Samurai samurai;

            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                Console.WriteLine(context.Samurais.Find(1).Name);
            }


            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                samurai = context.Samurais.Find(1);
            }


            //first way // low level way
            samurai.Name = "fst updated name";
            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                context.Entry(samurai).State = EntityState.Modified;
                context.SaveChanges();
            }


            //2nd way
            samurai.Name = "2nd updated name";
            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                context.Samurais.Update(samurai);
                context.SaveChanges();
            }


            //3rd way
            samurai.Name = "3rd updated name";
            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                context.Update(samurai);
                context.SaveChanges();
            }


            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                Console.WriteLine(context.Samurais.Find(1).Name);
            }
        }

        private static void LastOrDefaultProperWayOFUse()
        {

            var default_color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("see query . wrong way for large tables, but ok for small tables");
            Console.ForegroundColor = default_color;

            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                var samurai = context.Samurais.LastOrDefault();

                Console.WriteLine(samurai.Name);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("see query . good way for large tables, but good for small tables as well");
            Console.ForegroundColor = default_color;

            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                var samurai = context.Samurais.OrderBy(x => x.Id).LastOrDefault();

                Console.WriteLine(samurai.Name);
            }
        }

        private static void Like_New_Method_2_0()
        {
            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                foreach (var samurai in context.Samurais.Where(s => EF.Functions.Like(s.Name, "R%")))
                {
                    Console.WriteLine(samurai.Name);
                }
            }
        }

        private static void SelectFindByKey()
        {
            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                var samurai = context.Samurais.Find(1);
                Console.WriteLine(samurai.Name);
            }
        }

        private static void SelectSamurais()
        {
            using (SamuraiDbContext context = new SamuraiDbContext())
            {
                foreach (var samurai in context.Samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
        }

        private static void insertMultipleSamurai()
        {
            using (SamuraiDbContext conext = new SamuraiDbContext())
            {
                var samurai1 = new Samurai()
                {
                    Name = "Rakesh 12"
                };
                var samurai2 = new Samurai()
                {
                    Name = "Rakesh 12"
                };


                conext.Samurais.AddRange(samurai1, samurai2);
                conext.SaveChanges();
            }
        }

        private static void InsertSamurai()
        {
            using (SamuraiDbContext conext = new SamuraiDbContext())
            {
                var samurai = new Samurai() { Name = "Rakesh" };
                conext.Samurais.Add(samurai);
                conext.SaveChanges();
            }
        }
    }
}
