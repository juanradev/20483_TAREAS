using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace _90
{
    class Program
    {
        static void Main(string[] args)
        {

            if (!PerformanceCounterCategory.Exists("Application"))
            {
                var counterDC = new CounterCreationDataCollection();
                var IOTableRate = new CounterCreationData();
                IOTableRate.CounterName = "Data Trans/SEC";
                IOTableRate.CounterHelp = "Data transactions per second ";
                IOTableRate.CounterType = PerformanceCounterType.RateOfCountsPerSecond64;
                counterDC.Add(IOTableRate);

                PerformanceCounterCategory.Create("Application",
                        "Application Category for IOT data",
                        PerformanceCounterCategoryType.SingleInstance, counterDC);
                Console.WriteLine("categoria creada");
            }
            else
            {
                Console.WriteLine("categoria ya creada");
            }
        }
    }
}
