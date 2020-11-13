using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp172
{
    class Program
    {




        public static byte[] GetHashA(string filename, string algorithmType)
        {
           
            var hasher = HashAlgorithm.Create(algorithmType);
            var fileBytes = System.IO.File.ReadAllBytes(filename);
            var outputBuffer = new byte[fileBytes.Length];
            hasher.TransformBlock(fileBytes, 0, fileBytes.Length, outputBuffer, 0);
        //    hasher.TransformFinalBlock(fileBytes, fileBytes.Length - 1, fileBytes.Length);
            System.IO.File.WriteAllBytes(@".\..\..\salidaA.txt", outputBuffer);
            return outputBuffer;
        }
        public static int GetHashB(string filename, string algorithmType)
        {
            var hasher = HashAlgorithm.Create(algorithmType);
            var fileBytes = System.IO.File.ReadAllBytes(filename);
            hasher.ComputeHash(fileBytes);
           
            return hasher.GetHashCode();
        }
        public static byte[] GetHashC(string filename, string algorithmType)
        {
            var hasher = HashAlgorithm.Create(algorithmType);
            var fileBytes = System.IO.File.ReadAllBytes(filename);
            var outputBuffer = new byte[fileBytes.Length];
            hasher.TransformBlock(fileBytes, 0, fileBytes.Length, outputBuffer, 0);
            System.IO.File.WriteAllBytes(@".\..\..\salidaC.txt", outputBuffer);
            return (outputBuffer);
        }
        public static byte[] GetHashD(string filename, string algorithmType)
        {
            var hasher = HashAlgorithm.Create(algorithmType);
            var fileBytes = System.IO.File.ReadAllBytes(filename);
            hasher.ComputeHash(fileBytes);
            System.IO.File.WriteAllBytes(@".\..\..\salidaD.txt", hasher.Hash);
            return (hasher.Hash);
        }




        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                var salidaA = GetHashA( @".\..\..\fichero.txt", "SHA256");
            }
            catch (Exception ex)
            {
                Console.WriteLine("La opción A es erronea");
                Console.WriteLine($" Error en {ex.Source} : {ex.Message}");
                Console.WriteLine("");

            }
            var salidaB = GetHashB(@".\..\..\fichero.txt", "SHA256");
            Console.WriteLine($"La opcion B es erronea ya que  hasher.ComputeHash(fileBytes) devuelve un entero {salidaB}");

             var salidaC = GetHashC(@".\..\..\fichero.txt", "SHA256");
            Console.WriteLine($"La opcion C es erronea ya que  el valor devuelto está sin hashed {Encoding.Default.GetString(salidaC)}");
        
             var salidaD = GetHashD(@".\..\..\fichero.txt", "SHA256");
            Console.WriteLine($"La opcion D es correcta {Encoding.Default.GetString(salidaD)}");
            Console.ReadLine();
        }




}
}
