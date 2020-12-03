using System;
using System.Collections.Generic;

namespace _246
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myData = new List<string>();
            myData.Add("dato1");
            myData.Add("dato2");
            myData.Add("dato3");
            System.Console.WriteLine($"elementos:{myData.Count} y son :");
            foreach (string currentString in myData)
                System.Console.WriteLine(currentString);

            System.Console.WriteLine("iniciamos la eliminación");
            while (myData.Count != 0)
                myData.RemoveAt(0); 
            
            System.Console.WriteLine($"elementos:{myData.Count}");
        }

    }
}
