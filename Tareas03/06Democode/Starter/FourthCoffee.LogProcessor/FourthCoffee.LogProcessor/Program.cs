using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.LogProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
        //TODO 09: Replace [Repository Root] with your folder path 
        

            var logLocator = new LogLocator(@"D:\3- 20483\Allfiles\Mod06\Democode\Data\Logs\");
            var logCombiner = new LogCombiner(logLocator);

            logCombiner.CombineLogs(@"D:\20_610\20483\20483_TAREAS\Tareas03\06Democode\Data\LogsCombinedLog.txt");

        }
    }
}
