using System;
using System.Text;

namespace _73
{
    class Program
    {
        static void Main(string[] args)
        {
            string reallyLongString = @"En un lugar de la Mancha";
            var stringToFind = "En un lugar de la Mancha";
            StringBuilder sb = new StringBuilder(reallyLongString);
            Console.WriteLine($"sb.Equals(stringToFind)) {sb.Equals(stringToFind)}");
            Console.WriteLine($"sb.ToString (). IndexOf (stringToFind) {sb.ToString (). IndexOf (stringToFind)}");
            Console.WriteLine($"sb.ToString (). CompareTo (stringToFind) { sb.ToString (). CompareTo (stringToFind)}");
            Console.WriteLine($"sb.ToString (). Substring (stringToFind.Length) {sb.ToString (). Substring (stringToFind.Length)}");
            


        }
    }
}
