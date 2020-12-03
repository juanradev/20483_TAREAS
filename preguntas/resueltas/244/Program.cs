using System;
using System.Collections.Generic;
using System.Linq;

namespace _244
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> departaments = new List<string>()
            {"contabilidad","marketing","ventas","porduccion"};
            System.Console.WriteLine("buscando ventas tiene que salir TRUE");
            System.Console.WriteLine(GetMathes(departaments,"ventas"));
            System.Console.WriteLine("buscando saldosMartinez tiene que salir FALSE");
            System.Console.WriteLine(GetMathes(departaments,"saldosMartinez"));
        }
        private static bool GetMathes1(List<string> d, string searchTerm ) 
         {
             var finf = d.Exists((delegate(string name)
            {
                return (name.Equals(searchTerm));

            } ));

            return  finf;
            }
            private static bool GetMathes(List<string> d, string searchTerm ) 
         {
             var finf = d.Exists (x => x==searchTerm);
             

            return  finf;
            }
        }


    }


