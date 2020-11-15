using System;
using System.IO;

namespace _175
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().escribir();
        }

        public    void escribir ()
        {
            
            using (StreamWriter writer = new StreamWriter(@"d:\console.txt"))
            {
                try
                {
                    Console.SetOut (writer); //Establece la salida de consola a writer
                using (FileStream stream = new FileStream (@"d:\file.txt", FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader (stream))
                    {
                        while (!reader.EndOfStream) Console.WriteLine(reader.ReadLine());
                    }
                }
            }
            
            catch (Exception ex){
                Console.WriteLine (ex.Message + " " +  ex.GetType());
            }
            finally
            {
                    writer.Close();
            }
            }
        }
        
    }
}
