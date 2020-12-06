using System;

namespace _67
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double x, y;
            x=0.0; y = 0.0;
            System.Console.WriteLine($"double (0.00d/0.00d); {x/y}");
            float xf, yf;
            xf=0.00f; yf = 0.00f;
            System.Console.WriteLine($"float  (0.00f/0.00f); {xf/yf}");
            decimal xd, yd;
            xd=0.00m; yd = 0.00m;
            try{
                System.Console.WriteLine($"decimal (0.00d/0.00d); {xd/yd}");}

            catch (Exception ex )
            {
                System.Console.WriteLine($"decimal (0.00d/0.00d); {ex.Message}");  
            }
            int xi, yi;
            xi=0; yi=0;
           try{
                System.Console.WriteLine($"integer (0/0); {xi/yi}");
                }

            catch (Exception ex2 )
            {
                System.Console.WriteLine($"integer (0/0); {ex2.Message}");  
            }
 

        }
    }
}
