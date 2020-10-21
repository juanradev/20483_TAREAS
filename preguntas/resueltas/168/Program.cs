using System;

namespace _168
{
    class Program
    {
        static void Main(string[] args)
        {
            float amount = 273.56F;
            ConvertAmount(amount);
            Console.ReadLine();
        }

        private static void ConvertAmount(float amount)
        {
            Console.WriteLine($" amount en ConvertAmount {amount} ");
            TransferFunds(amount);
        }
 
private static void TransferFunds(float funds)
        {
            Console.WriteLine($" funds en TransferFunds {funds} ");
        }

    }
}
