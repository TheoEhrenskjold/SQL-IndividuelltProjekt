using Microsoft.EntityFrameworkCore;
using SQL_IndividuelltProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SQL_IndividuelltProjekt
{
    internal class PersonalKlass
    {
        public static void AllEmp()
        {
            Console.Clear();
            Console.WriteLine("[1]Lägga till anställd?");
            Console.WriteLine("[2]Lärare och ämnen");
            Console.WriteLine("[3]Alla lärare");
            Console.WriteLine("[3]All personal");
            var Emp = Console.ReadLine();

            switch (Emp)
            {
                case "1":
                    {
                        PersonalKlass.AddEmp();
                    }
                    break;
                case "2":
                    {
                        PersonalKlass.TeacherDep();
                    }
                    break;
                case "3":
                    {
                        PersonalKlass.AllTeachers();
                    }
                    break;
                    case "4":
                    {
                        PersonalKlass.AllPersonal();
                    }
                    break;
            }

                
            
            
        }
        public static void AddEmp()
        {
            Console.Clear() ;
            using SchoolDbContext context = new SchoolDbContext();
            Console.WriteLine("Vad heter den anställda?");
            var anställdnamn = Console.ReadLine();
            Console.WriteLine($"Vilken befattning har {anställdnamn}");
            var anställdbefattning = Console.ReadLine();

            if (anställdbefattning == "lärare")
            {
                Console.WriteLine("Vilket ämne ansvarar din lärare för?");
                var lärarämne = Console.ReadLine();
                Lärare lärare = new Lärare();
                {
                    lärare.Namn = anställdnamn;
                    lärare.Ämne = lärarämne;
                }
                context.Add(lärare);
                Personal personal = new Personal();
                {
                    personal.Namn = anställdnamn;
                    personal.Befattning = anställdbefattning;
                }
                context.Add(personal);
            }

            else
            {
                Personal personal = new Personal();
                {
                    personal.Namn = anställdnamn;
                    personal.Befattning = anställdbefattning;
                }
                context.Add(personal);
            }


            context.SaveChanges();
            Console.WriteLine($"{anställdnamn} har lagts till i databasen.");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadKey();
        }
        public static void AllTeachers()
        {
            Console.Clear();
            using SchoolDbContext context = new SchoolDbContext();
            var LärarSök = context.Lärares.Where(p => p.LärarId != null).OrderBy(p => p.Namn);

            foreach (Lärare item in LärarSök)
            {
                Console.WriteLine($"Namn: {item.Namn}");
                Console.WriteLine($"Ämne: {item.Ämne}");                
                Console.WriteLine(new string('-', 20));
            }
            Console.WriteLine("Tryck Enter för att fortsätta");
            Console.ReadKey();

        }
        public static void TeacherDep()
        {
            Console.Clear();
            using SchoolDbContext context = new SchoolDbContext();
            var lärarePerAvdelning = context.Lärares.Where(p => p.Ämne != null).GroupBy(p => p.Ämne).Select(g => new
            {
             Ämne = g.Key,
             AntalLärare = g.Count()
            })
            .ToList();

            foreach (var ämne in lärarePerAvdelning)
            {
                Console.WriteLine($"Avdelning: {ämne.Ämne}, Antal lärare: {ämne.AntalLärare}");
            }
            Console.ReadKey( );
        }
        public static void AllPersonal()
        {
            Console.Clear();
            using SchoolDbContext context = new SchoolDbContext();
            Console.Clear();
            var PersonalSök = context.Personals.Where(p => p.PersonalId != null).OrderBy(p => p.Namn);
            foreach (Personal item in PersonalSök)
            {
                Console.WriteLine($"Namn: {item.Namn}");
                Console.WriteLine($"Befattning: {item.Befattning}");
                //Console.WriteLine($"Befattning: {item.Anställning}");
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}
