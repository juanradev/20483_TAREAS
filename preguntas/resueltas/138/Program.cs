using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _138
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lista = new List<string> () {"12.36","-12.36","abc","12.00","12"};
            foreach (var item in lista)
            {
                opcionc(item);
            }
        }

        public static void opcionc( string price){
            
            string mensaje = $"Prueba opcion a {price}";
           
            Regex reg = new Regex( @"^\d+(\.\d\d)?$");
            //Regex reg = new Regex( @"^(\d{1}\.)?(\d+\.?)+(,\d{2})?$");
            if (reg.IsMatch(price)) 
                System.Console.WriteLine($"{mensaje} valid Price");
            else
                  System.Console.WriteLine($"{mensaje} INVALID Price");
            
        }
    }
}
