using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace _121
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<string> listaa= new List<string> ();
            List<string> listab= new List<string> ();
            List<string> listac = new List<string>();
            List<string> listad = new List<string>();
           
            listab = TestIfWebSiteb("http://www.googole.com");
            listac = TestIfWebSitec("http://www.googole.com");
            listad = TestIfWebSited("http://www.googole.com");
            Console.WriteLine($"lista A {listaa.Count}");
            Console.WriteLine($"lista B {listab.Count}");
            Console.WriteLine($"lista C {listac.Count}");
            foreach (string s in listac) Console.WriteLine(s);
            Console.WriteLine($"lista D {listad.Count}");
            foreach (string s in listad) Console.WriteLine(s); 
        }

        public static List<string> TestIfWebSitea(string url)
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
                Console.WriteLine(ex.Source + " " + ex.GetType() + " " + ex.Message);
            }
            return result;
        }
        public static List<string> TestIfWebSiteb(string url)
        {
            const string pattern = @"http://(www\.)?([^\.]+)\.com";
            List<string> result = new List<string>();

            MatchCollection myMatches = Regex.Matches(url, pattern);
            result = (from Match m in myMatches
                      where m.Value.Contains(pattern)
                      select m.Value).ToList<string>();

            return result;
        }
        public static List<string> TestIfWebSitec(string url)
        {
            const string pattern = @"http://(www\.)?([^\.]+)\.com";
            List<string> result = new List<string>();

            MatchCollection myMatches = Regex.Matches(url, pattern);
            foreach (Match currentMatch in myMatches)
                result.Add(currentMatch.Groups.ToString());

            return result;
        }
        public static List<string> TestIfWebSited(string url)
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
