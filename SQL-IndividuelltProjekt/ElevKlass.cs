using Microsoft.EntityFrameworkCore;
using SQL_IndividuelltProjekt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_IndividuelltProjekt
{
    internal class ElevKlass
    {
        public static void AllStu()
        {
            using SchoolDbContext context = new SchoolDbContext();

            Console.Clear();
            var Elever = context.Students.Where(p => p.Namn != null).OrderBy(p => p.Namn);
            foreach (Student item in Elever)
            {
                Console.WriteLine($"Namn: {item.Namn}");
                Console.WriteLine($"Personnummer: {item.Personnummer}");
                if (item.KlassId == 1) { Console.WriteLine("Klass: Sut23"); }
                else if (item.KlassId == 2) { Console.WriteLine("Klass: 9:B"); }
                else if (item.KlassId == 3) { Console.WriteLine("Klass: 3:A"); }

                Console.WriteLine(new string('-', 20));
            }

            Console.WriteLine("[1]Sätt ett nytt betyg");
            Console.WriteLine("[2]Huvudmeny.");
            var AllStumeny = Console.ReadLine();
            switch (AllStumeny)
            {
                case "1":
                    {
                        Betyg();
                    };
                    break;
                case "2":
                    {

                    };
                    break;
            }
            Console.ReadKey();
        }

        public static void Betyg()
        {
            using SchoolDbContext context = new SchoolDbContext();

            Console.Clear();
            var Elever = context.Students.Where(p => p.Namn != null).OrderBy(p => p.Namn);
            foreach (Student item in Elever)
            {
                Console.WriteLine($"Namn: {item.Namn}");
                Console.WriteLine($"Student ID: {item.StudentId}");
                Console.WriteLine(new string('-', 20));
            }


            Console.Write("Student ID: ");
            var studentID = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            var KursSök = context.Kurs.Where(p => p.KursId != null).OrderBy(p => p.Kursnamn);
            foreach (Kur item in KursSök)
            {
                Console.WriteLine($"Kurs ID: {item.KursId}");
                Console.WriteLine($"Ämne: {item.Kursnamn}");
                Console.WriteLine(new string('-', 20));
            }
            Console.Write("Kurs ID: ");
            var KursIDInput = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            var LärarSök = context.Lärares.Where(p => p.LärarId != null).OrderBy(p => p.Namn);

            foreach (Lärare item in LärarSök)
            {
                Console.WriteLine($"Namn: {item.Namn}");
                Console.WriteLine($"Ämne: {item.Ämne}");
                Console.WriteLine($"Ämne: {item.LärarId}");
                Console.WriteLine(new string('-', 20));
            }
            Console.Write("Lärar ID: ");
            var LärarIDInput = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("5 - Högsta betyg");
            Console.WriteLine("4 - Väl Godkänt");
            Console.WriteLine("3 - Godkänt");
            Console.WriteLine("2 - Underkänt");
            Console.WriteLine("1 - Mycket Underkänt");
            var ValtBetyg = Convert.ToInt32(Console.ReadLine());

            Betyg betyg = new Betyg();
            {
                betyg.BetygsId = 4;
                betyg.StudentId = studentID;
                betyg.KursId = KursIDInput;
                betyg.LärarId = LärarIDInput;
                betyg.Betyg1 = ValtBetyg;
                //betyg.Datum = betygDatum;
            }
            Console.Clear();
            Console.WriteLine("Datum betyget sattes ''XXXX-XX-XX''");
            var betygDatum = Console.ReadLine();
            if (DateTime.TryParse(betygDatum, out DateTime gradeDate))
            {
                betyg.Datum = gradeDate;

                context.Betygs.Add(betyg);
                context.SaveChanges();
            }

            Console.WriteLine("Uppdaterar databasen med det nya betyget...");
            Thread.Sleep(200);
        
    


        }
    

        
        
    }

}
