using System;
using System.IO;

namespace _24
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("LECTURA FICHERO EXITE");
            leer("log.txt");
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("LECTURA FICHERO NO EXITE");
            try
            {
                leer("NOEXISTE.txt");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("ERROR MOSTRADO EN MAIN /n" + ex.ToString());
            }

        }

        static void leer(string fichero)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fichero))
                {

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        System.Console.WriteLine(line);
                    }

                }
            }
            catch (FileNotFoundException e)
            {
                System.Console.WriteLine("ERROR MOSTRADO EN PROCEDIMIENTO /n" + e.ToString());
                throw;

            }
        }
    }
}
