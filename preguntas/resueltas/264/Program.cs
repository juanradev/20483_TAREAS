using System;

namespace _264
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = {1,2,3,4,5};
            int suma=0;
            for (int i =0; i < Array.Length; i++)
            {
                suma += Array[i]; 
                Array[i++]= suma;
            }
            foreach(var item in Array)
            System.Console.WriteLine(item);
        }
    }
}
