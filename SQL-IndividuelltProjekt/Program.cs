using SQL_IndividuelltProjekt.Models;

namespace SQL_IndividuelltProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();                

                Console.WriteLine("[1] Elever");
                Console.WriteLine("[2] Personal");
                Console.WriteLine("[3] Klasser");
                var Mainmenu = Console.ReadLine();
                switch (Mainmenu)
                {
                    case "1":
                        {
                            ElevKlass.AllStu();

                        }
                        break;

                    case "2":
                        {
                            PersonalKlass.AllEmp();
                        }
                        break;

                    case "3":
                        {
                            KlassKlass.AllClasses();
                        }
                        break;                        
                        
                }

            }
        }
    }
}
