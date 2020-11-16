using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _240
{
    class Program
    {
        static void Main(string[] args)
        {
            var pagina = GetAsync("https://dotnetfoundation.org/");
            Console.WriteLine(pagina.Result);
        }

        public static async Task <string> GetAsync(string uri)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync (uri);
            return await Task.Run (() => content); 
        }
    }
}
