using System;

namespace _19
{
    class Program
    {
        static void Main(string[] args)


        {
            Console.WriteLine("Introduce un caracter a=animal m=mineral");
            ConsoleKeyInfo k = Console.ReadKey(true);
            char letter  ;
            try{
                    letter = (char) k.KeyChar;
                    Console.WriteLine($"Pulsaste { letter} respuesta: {GetResponse(letter)}");
                    Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocurrió una excepcion {e.Message}");

            }

        }
    
    
    static public string GetResponse(char letter)
{
    string response;
    switch (letter)
    {
        case 'a': 
            response="animal";
            break;
        case 'm':
            response="mineral";
            break;
        default:
            response="invalide choice";
            break;
    }
    return (response);

}
    
    }
}
