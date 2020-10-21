using System;
using System.Linq;
using System.Collections.Generic;

namespace _20
{
    class Program
    {
        static void Main(string[] args)
        {
            	string [] vehicules = {"Airplane","Boat","Car"};
                List <string> aVehicules = 
                    ( from    vehicle in vehicules
                    where vehicle.StartsWith("A")
                    select vehicle). ToList<string>();
                
                foreach (var vehicle in aVehicules)
                {
                    Console.WriteLine(vehicle);
                }
                Console.ReadLine();
        }
    }
}
