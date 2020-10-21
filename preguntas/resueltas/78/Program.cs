using System;
using System.Diagnostics.CodeAnalysis;
using static System.Console;


namespace _78
{
    class Program
    {

        public class CLass1 : IEquatable<CLass1>
        {
            public Int32 ID { get; set; }
            public String Name { get; set; }

            public CLass1(Int32 id, string name)
            {
                ID = id; Name = name;
            }
            public bool Equals([AllowNull] CLass1 other)
            {

                if (other == null) return false;
                if (!this.Name.Equals(other.Name)) return false;
                if (this.ID != other.ID) return false;
               // return true;
            }
            public override string ToString()//
            {
                return ($"ID: {ID.ToString()} Name : {Name}");
            }

            static void Main(string[] args)
            {
                CLass1 prueba1 = new CLass1(12, "Europa");
                CLass1 prueba2 = null;
                WriteLine(prueba1.ToString());
                WriteLine($"null, Debe ser False y no lanzar excepcion  >> Resultado:  {prueba1.Equals(prueba2)}");
                prueba2 = new CLass1(12, "Europa");
                WriteLine(prueba1.ToString() + " = " + prueba2.ToString() + ($" Resultado:  {prueba1.Equals(prueba2)}"));
                prueba2.Name = "Rusia";
                WriteLine(prueba1.ToString() + " = " + prueba2.ToString() + ($" Resultado:  {prueba1.Equals(prueba2)}"));
                prueba2.ID = 125;
                WriteLine(prueba1.ToString() + " = " + prueba2.ToString() + ($" Resultado:  {prueba1.Equals(prueba2)}"));
                prueba2.Name = "Europa";
                WriteLine(prueba1.ToString() + " = " + prueba2.ToString() + ($" Resultado:  {prueba1.Equals(prueba2)}"));
            }
        }
    }
}
