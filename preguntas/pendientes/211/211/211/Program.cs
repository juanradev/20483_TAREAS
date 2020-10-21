using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _211
{
    class Program
    {
        static void Main(string[] args)
        {
			//CreateCounters();
		 
			 checked
			{
				byte b = byte.MaxValue;
				Console.WriteLine(b);               // b=255
				try
				{
					Console.WriteLine(++b);
				}
				catch (OverflowException e)
				{
					Console.WriteLine(e.Message);   // "Arithmetic operation resulted in an overflow." 
													// b = 255
				}
				Console.ReadLine();

			}
		}


		/*static void CreateCounters()
		{
			if (!PerformanceCounterCategory.Exists("Contoso"))
			{
				var counters = new CounterCreationDataCollection();
				var ccdCounter1 = new CounterCreationData();
				ccdCounter1.CounterName = "Counter1";
				ccdCounter1.CounterType = PerformanceCounterType.SampleFraction;
				counters.Add(ccdCounter1);


				var ccdCounter2 = new CounterCreationData();
				ccdCounter2.CounterName = "Counter2";
				ccdCounter2.CounterType = PerformanceCounterType.;
		
				counters.Add(ccdCounter2);

				PerformanceCounterCategory.Create("Contoso", "Help string", PerformanceCounterCategoryType.MultiInstance, counters);
			} 
		}*/
	}
}
