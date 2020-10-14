using System;

namespace _252
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 1, 2, 3, 4, 5 };
int sum = 0;
for (int i=0; i < intArray.Length;i++)
{
    sum += intArray[i];
	intArray[i] = sum;
	Console.WriteLine (sum);
	
}      

            foreach (var item in intArray)
                    {
                        Console.WriteLine(item);
                    }

        }
    }
}
