using System;

namespace _176
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().division(5.0m, 0.0m);

        }

  public void division(decimal divisor, decimal dividendo)
        {

            try
            {
                Console.WriteLine(divisor / dividendo);
            }
            catch (DivideByZeroException e) { Console.WriteLine("Divide By Zero" + e.Message); }
            catch (ArithmeticException e) { Console.WriteLine("Arithmetic Error " + e.Message); }
            catch (ArgumentException e) { Console.WriteLine("Bad Argument" + e.Message); }
            catch (Exception e) { Console.WriteLine("General Erro" + e.Message); }
        }
    }
}


