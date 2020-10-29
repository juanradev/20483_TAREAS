using System;

namespace _44
{
    class Program
    {
        static void Main(string[] args)
        {
            Estudiante estudiante1 = new Estudiante("CEIP Montserrrat", "Juan");
            estudiante1.mostrar();
        }


    }

    public class Persona
    {
        protected string nombre { get; set; }
        public Persona(string nombre)
        {
            this.nombre = nombre;
        }
        public string GetPersona_public()
        {
            return ($"{this.nombre} GetPersona_public ");
        }
        protected internal string GetPersona_protectedinternal()
        {
            return ($"{this.nombre}  GetPersona_protectedinternal");
        }
        protected string GetPersona_protected()
        {
            return ($"{this.nombre}  GetPersona_protected");
        }
        internal string GetPersona_internal()
        {
            return ($"{this.nombre}  GetPersona_internal");
        }
        private string GetPersona_private()
        {
            return ($"{this.nombre}  GetPersona_private");
        }
    }
    public class Estudiante : Persona
    {
        protected string colegio { get; set; }
        public Estudiante(string colegio, string nombre) : base(nombre)
        {
            this.colegio = colegio;
        }
        public void mostrar()
        {
            Console.WriteLine(base.GetPersona_protectedinternal());
            Console.WriteLine(base.GetPersona_internal());
            Console.WriteLine(base.GetPersona_protected());
            Console.WriteLine(base.GetPersona_public());
        }
    }

}