using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace _161
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> listaa= new List<string> ();
            List<string> listab= new List<string> ();
            List<string> listac = new List<string>();
            List<string> listad = new List<string>();
            listaa = TestIfWebSitea("http://www.googole.com");
            Console.WriteLine($"lista A {listaa.Count}");
            foreach (string s in listaa) Console.WriteLine(s);
            Console.WriteLine();
            
            listab = TestIfWebSiteb("http://www.googole.com");
             Console.WriteLine();
            listac = TestIfWebSitec("http://www.googole.com");
            Console.WriteLine($"lista C {listac.Count}");
            foreach (string s in listac) Console.WriteLine(s); 
            Console.WriteLine();
            listad = TestIfWebSited("http://www.googole.com");

            
        }

        public static List<string> TestIfWebSited(string url)
        {
            const string pattern = @"http://(www\.)?([^\.]+)\.com";
            List<string> result = new List<string>();

            MatchCollection myMatches = Regex.Matches(url, pattern);
            try
            {
                result = (List<string>)myMatches.SyncRoot;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Opcion A" + " " + ex.GetType() + " " + ex.Message);
            }
            return result;
        }
        public static List<string> TestIfWebSiteb(string url)
        {
            const string pattern = @"http://(www\.)?([^\.]+)\.com";
            List<string> result = new List<string>();

            MatchCollection myMatches = Regex.Matches(url, pattern);
            try{
            result =(List<string>)myMatches.GetEnumerator();
            }     
             catch (Exception ex)
            {
                Console.WriteLine("opcion B" + " " + ex.GetType() + " " + ex.Message);
            }
            return result;
        }
        public static List<string> TestIfWebSitea(string url)
        {
            const string pattern = @"http://(www\.)?([^\.]+)\.com";
            List<string> result = new List<string>();

            MatchCollection myMatches = Regex.Matches(url, pattern);
            foreach (Match currentMatch in myMatches)
                result.Add(currentMatch.Groups.ToString());

            return result;
        }
        public static List<string> TestIfWebSitec(string url)
        {
            const string pattern = @"http://(www\.)?([^\.]+)\.com";
            List<string> result = new List<string>();

            MatchCollection myMatches = Regex.Matches(url, pattern);
            foreach (Match currentMatch in myMatches)
                result.Add(currentMatch.Value);
            return result;
        }

    }
}