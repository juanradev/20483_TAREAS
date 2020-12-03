using System;

namespace _76
{
   
    public class AdVentureWorksException : System.Exception{}
    public class AdVentureWorksDbException : AdVentureWorksException {}
    public class AdVentureWorksValidationException : AdVentureWorksException {}


    class Program
    {

        static void Log (Exception ex) {
            System.Console.WriteLine($"1.- Exception log  {ex.GetType()}");
        }

        static void Log (AdVentureWorksException ex) {
            System.Console.WriteLine($"2. - AVWORKS  log  {ex.GetType()}");
        }

        static void Log (AdVentureWorksValidationException ex) {
            System.Console.WriteLine($"3. AVWORKS Validation log  {ex.GetType()}");
        }

        static void Main(string[] args)
        {
            try 
            {
               DoWork(args[0]);
            }

            catch (AdVentureWorksValidationException ex )
            {
                Log(ex ); 
            }
            catch (AdVentureWorksException ex )
            {
                Log(ex);
            }
            catch (Exception ex )
            {
                Log(ex);
            }
        }

        public static void fallo1(){  throw (new AdVentureWorksValidationException ());}
        public static void fallo2(){  throw (new AdVentureWorksDbException ());}
        public static void fallo3(){  throw (new AdVentureWorksException ());}
        public static void DoWork(string tipo)
        {
            System.Console.WriteLine("doWork");
            switch (tipo) {
                 

                case "0": 
                System.Console.WriteLine("lanzaremos AdVentureWorksValidationException");
                System.Console.WriteLine("debera Ejecutar Log(AdventureWorksValidationException ex)");
                fallo1();
                break;
                case "1": 
                System.Console.WriteLine("lanzaremos AdVentureWorksDbException");
                System.Console.WriteLine("debera Ejecutar Log(AdventureWorksException ex)");
                fallo2();
                break;
                case "2": 
                System.Console.WriteLine("lanzaremos AdventureWorksException");
                System.Console.WriteLine("debera Ejecutar Log(AdventureWorksException ex)");
                fallo2();
                break;
                default: 
                System.Console.WriteLine("lanzaremos otra excepcion");
                System.Console.WriteLine("debera Ejecutar Log(Exception ex)");
                throw (new Exception ());
            }
            
        }
    }
}


