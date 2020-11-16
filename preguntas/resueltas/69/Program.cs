using System;
using System.Threading.Tasks;
using System.Threading;

namespace _69
{
    class Program
    {
        static   void Main(string[] args)
        {
            var l1 =   Class1.Method1(20);
            var l2 =   Class1.Method1(5);
            var l3 =   Class1.Method1(1);
             Console.WriteLine($"Retorno de l1 { l1.Result}");
             Console.WriteLine($"Retorno de l2 { l2.Result}");
             Console.WriteLine($"Retorno de l3 { l3.Result}");
        }

 
}
    public static class Class1 {
        public static async Task<decimal> Method1(int parameter1)
        {
             await Task.Run(() =>
               {
                 // Simulate a long-running task.
                  Thread.Sleep(parameter1 * 100);
                
               });
            Console.WriteLine($"fin de la operacion con valor {parameter1}");
            return (decimal) parameter1 * 100;
        }
    }
}
