using System;

namespace _257
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 1;
            int b = 2;
            Console.WriteLine($"a={a}, b={b}");
            Console.WriteLine(a == --b && a == b++);
            Console.WriteLine($"a={a}, b={b}");
            Console.WriteLine(a == --b || a == b++);
            Console.WriteLine($"a={a}, b={b}");
            Console.WriteLine(a == --b && b == a++);
            Console.WriteLine($"a={a}, b={b}");
        }
    }
}
