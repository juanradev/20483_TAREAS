using System;

namespace _255
{
    class Program
    {
        static void Main(string[] args)
        {
            var valor1  = 72;
            var valor2 = 3;
            Console.WriteLine($"{valor1} es un mayor que 5  {valor1.mayorquecinco()}");
            Console.WriteLine($"{valor2} es un mayor que 5  {valor2.mayorquecinco()}");
          }
    }
    public static class ExtensionMethods
    {
        public static bool mayorquecinco(this Int32 entrada)
        {
            var regEx = (entrada > 5);
            return regEx;
        }
    }
}

