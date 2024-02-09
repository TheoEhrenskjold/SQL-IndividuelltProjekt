using SQL_IndividuelltProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_IndividuelltProjekt
{
    internal class KlassKlass
    {
        public static void AllClasses()
        {
            using SchoolDbContext context = new SchoolDbContext();
            Console.Clear();
            var KlassSök = context.Klasses.Where(p => p.KlassId != null).OrderBy(p => p.Klassnamn);
            Console.WriteLine("Alla aktiva klasser: ");
            foreach (Klass item in KlassSök)
            {
                Console.WriteLine($"Klass: {item.Klassnamn}");                                
                Console.WriteLine(new string('-', 20));
            }
            Console.WriteLine("Tryck Enter för att fortsätta");
            Console.ReadKey();
        }
    }
}
