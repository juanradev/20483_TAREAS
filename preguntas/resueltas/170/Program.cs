using System;

namespace _170
{
    class Program
    {
        static void Main(string[] args)
        {

            int statusCode = int.Parse(args[0]);
            string statusText;
            switch (statusCode)
            {
                case 0:
                    statusText = "Error";
                    break;
                case 1:
                    statusText = "Success";
                    break;
                default:
                    statusText = "Unauthorized";
                    break;

            }
            Console.WriteLine(statusText);


/*
            statusText = statusCode switch
            {
                0 => "ERROR",
                1 => "SUCESS",
                _ => "Unauthorized",

            };
           Console.WriteLine(statusText);

*/
        }



    }
}
