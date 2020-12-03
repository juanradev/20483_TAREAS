using System;

using System.Collections.Generic;

using System.Linq;

using System.Text.RegularExpressions;


namespace _57
{
    class Program
    {

        
        static void MostrarResultado ( string opcion, List<string> lista)
        {
            Console.Write($"Opción: {opcion}    :   ");

            foreach(var item in lista) Console.WriteLine($"resultado :{item}");
            if (lista.Count == 0 )Console.WriteLine("");

        }
        static void Main(string[] args)
        {






             const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
             // la he recogido de https://docs.microsoft.com/es-es/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format#:~:text=Usar%20una%20expresi%C3%B3n%20regular%20para%20validar%20un%20correo,la%20estructura%20de%20un%20correo%20electr%C3%B3nico%20es%20v%C3%A1lida.
             const string entradavalida  ="john@doe.com";

            System.Console.WriteLine($"prueba con {entradavalida}");
            MostrarResultado ("A",A_GetValidEmailAddresses(entradavalida,pattern));
            MostrarResultado ("B",B_GetValidEmailAddresses(entradavalida,pattern));
            MostrarResultado ("C",C_GetValidEmailAddresses(entradavalida,pattern));
            MostrarResultado ("D",D_GetValidEmailAddresses(entradavalida,pattern));  

             const string entradanovalida  ="pepe@pepe@pepe";
            System.Console.WriteLine($"prueba con {entradanovalida}");
            MostrarResultado ("A",A_GetValidEmailAddresses(entradanovalida,pattern));
            MostrarResultado ("B",B_GetValidEmailAddresses(entradanovalida,pattern));
            MostrarResultado ("C",C_GetValidEmailAddresses(entradanovalida,pattern));
            MostrarResultado ("D",D_GetValidEmailAddresses(entradanovalida,pattern));               

        }
        
        private static List<String> A_GetValidEmailAddresses(string input, string pattern)
        {
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);
            var validEmailAddresses = new List<String>();
            foreach(Match match in matches)
            {
                if(match.Success)
                {
                    validEmailAddresses.Add(match.Value);
                }
            }
            return validEmailAddresses;
        } 

        private static List<String> B_GetValidEmailAddresses(string input, string pattern)
        {
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);
            var validEmailAddresses = new List<String>();
            foreach(Match match in matches)
            {
                if(!match.Success)
                {
                    validEmailAddresses.Add(match.Value);
                }
            }
            return validEmailAddresses;
        }
        private static List<String> C_GetValidEmailAddresses(string input, string pattern)
        {
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);
            return ( from Match match in matches where match.Success select match.Value).ToList();
         
        }
        private static List<String> D_GetValidEmailAddresses(string input, string pattern)
        {
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);
            return ( from Match match in matches where match.Success select match.Success.ToString()).ToList();
         
        }



    }
}