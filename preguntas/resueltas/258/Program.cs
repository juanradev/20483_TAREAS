using System;
using System.Collections.Generic;
using System.Linq;

namespace _258
{
    class Program
    {
        static void Main(string[] args)
        {
             List<int> items = new List<int>() {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};

             var page = items.Skip(5).Take(5);

             foreach (int i in page)
             {
                 Console.WriteLine (i);
             }
        }
    }
}
