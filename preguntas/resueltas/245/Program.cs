using System;

namespace _245
{
    class Program
    {
    private static string UppercaseString(string inputString)
    {
        return inputString.ToUpper();
    }
   public static void Main()
   {
      Func<string, string> convertMethod = UppercaseString;  // Fun<T,TResult> delegado
      
      string name = "Dakota";
      // Use delegate instance to call UppercaseString method
      Console.WriteLine(convertMethod(name));
   }


 }
}