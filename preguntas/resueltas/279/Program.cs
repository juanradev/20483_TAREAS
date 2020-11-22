using System;
using System.Diagnostics;

namespace _279
{
    [DebuggerDisplay("Mydebug")]
    public class Prueba
    { public string valor { get; set; }
    }


    class Program
    {
        
        static void Main(string[] args)
        {
            #if DEBUG

            Console.WriteLine("Entorno DEV");

#else

            Console.WriteLine("Entorno RELEASE");

#endif
            Console.ReadKey();
        }
    }
}
