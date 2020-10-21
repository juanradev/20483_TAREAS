using System;
using System.Collections.Generic;
using System.Linq;
using static    System.Console;

namespace _139
{
    class Program
    {
        static void Main(string[] args)
        {
            List <Int32> items =new List<int> () {
                100,
                95,
                80,
                75,
                95
            };



            WriteLine("where i >80 : devolvería los mayore de 80");
            var result = from i in items 
                where i > 80
                    select i;
            foreach(var i in result){
                WriteLine(i.ToString());
            }
             WriteLine("Take : devolvería los 80 primeros");
            result = items.Take(80);
            foreach(var i in result){
                WriteLine(i.ToString());
            }
            WriteLine("Skip : devolvería los siguientes despues de los 80 primeros");
            result = items.Skip(80);
            foreach(var i in result){
                WriteLine(i.ToString());
            }

        }
    }
}
