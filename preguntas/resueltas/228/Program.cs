using System;

namespace _228
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((convertTheDouble (args[0])).ToString());
        }

        static public double convertTheDouble( string aParam)
        {
                double result;
                if (!(double.TryParse(aParam, out result)))
                {
                    return 0;
                }
                return result;
        }
    }
}
