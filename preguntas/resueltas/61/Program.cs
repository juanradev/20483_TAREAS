using System;


namespace _61
{
    class Program
    {
        static void Main(string[] args)
        {
            
            float t = 123.45f;
            Console.WriteLine(t);
            FloorTemperature (t);
            
        }
   
        public static void FloorTemperature(float degrees)
        {
            object degreesRef = degrees;
Console.WriteLine(degreesRef);
            try {
                int r1 = (int) degreesRef;
                Console.WriteLine($"a ) int result = (int) degreesRef {r1}");
            }
            catch(Exception  ex)
            {
                Console.WriteLine($"a ) int result = (int) degreesRef :    {ex.Message }");
            }
            try {
                 int r2 = (int)(double) degreesRef;
                  Console.WriteLine($"b ) int result = (int)(double) degreesRef {r2 }");
            }
            catch(Exception  ex)
            {
                  Console.WriteLine($"b ) int result = (int)(double) degreesRef :    {ex.Message }");
            }
            try {
                int r3 = (int) degreesRef;
                     Console.WriteLine($"c ) int result = (int) degreesRef; {r3}");
            }
            catch(Exception   ex)
            {
                     Console.WriteLine($"c ) int result = (int) degreesRef;  :    {ex.Message}");
            }

            try {
                  int r4 = (int)(float)  degreesRef;
                Console.WriteLine($"d ) int result = (int)(float)  degreesRef; {r4}");
            }
            catch(Exception  ex)
            {
                Console.WriteLine($"d ) int result = (int)(float)  degreesRef; :    {ex.Message }");
            }

        }

    }
}
