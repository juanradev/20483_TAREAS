using System;
using System.Collections;
using System.Collections.Generic;

namespace _95
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array1 = new ArrayList();
            int var1 = 10;
            int var2;
            array1.Add(var1);	
          //  var2 = ((List<int>)array1)[0]  ;
            var2 = (int)array1[0]; 
          //  var2 = ((int[])array1)[0]; 
          //  var2 = array1[0] as int; 

          Console.WriteLine(var2);
        }
    }
}

