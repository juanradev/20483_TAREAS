using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace _283
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.AutoFlush = true;
            Debug.Indent();
          
            decimal valor = CalculateInterest(12.23m, 25, 7);
         
            valor = CalculateInterest(-12.23m, 25, 7);
        Console.ReadKey();
        }

    private static decimal CalculateInterest(decimal loanAmount, int loanTerm, int loanRate)
    {
        decimal interestAmount = loanAmount * loanTerm * loanRate;
        Debug.WriteLine(loanAmount > 0);
        Console.WriteLine($"DEBUG.WRITE PASS con loanAmount {loanAmount}");

        Trace.WriteLine(loanAmount > 0);
        Console.WriteLine($"TRACE.WRITE PASS con loanAmount {loanAmount}");

        Debug.Assert(loanAmount > 0);
        Console.WriteLine($"DEBUG.ASSERT PASS con loanAmount {loanAmount}");


            Trace.Assert(loanAmount >= 0);
            Console.WriteLine($"Trace.ASSERT PASS con loanAmount {loanAmount}");
            Console.WriteLine("");
            Console.WriteLine("");
            return interestAmount;
          

        }
}
}
