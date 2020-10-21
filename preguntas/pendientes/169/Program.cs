using System;

namespace _169
{
    class Program
    {
        static void Main(string[] args)
        {
 
                    opciona();
 
                    opcionb();
 
                    opcionc();
 
                    opciond();
 
            Console.ReadLine();
        }

        static void opciona()
        {   Console.WriteLine("opcion a:");
#if (TRACE)
            Console.WriteLine("entering debug mode");
#else
                Console.WriteLine("entering release mode");
#endif


        }
        static void opcionb()
        {   Console.WriteLine("opcion b:");
#if (DEBUG)
            Console.WriteLine("entering debug mode");
#else
             Console.WriteLine("entering release mode");
#endif

        }
        static void opcionc()
        {
            Console.WriteLine("opcion c:");
            if (System.Diagnostics.Debugger.IsAttached)
                Console.WriteLine("entering debug mode");
            else
                Console.WriteLine("entering release mode");
        }
        static void opciond()
        {
            Console.WriteLine("opcion d:");
            #region DEBUG
            Console.WriteLine("entering debug mode");
            #endregion
            #region RELEASE
            Console.WriteLine("entering release mode");
            #endregion

        }
    }
}
