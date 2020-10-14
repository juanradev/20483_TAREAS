using System;
using System.Collections;
using System.Collections.Generic;
namespace _84
{
    class Program
    {
        static void Main(string[] args)
        {
            	ArrayList array1 = new ArrayList();
                 	int var1 = 10;
                 	int var2;
                 	array1.Add(var1);
                    var2 = Convert.ToInt32(array1 [0]);

                    Console.WriteLine(var2);
        }
    }
}
