
/*
punblic class CLASE

        public delegate void delegado (objeto obj, EventArgs args);
        public event delegado evento
        if (evento != null)
            evento(this, e);

        public static void metodo(Coffee cof, EventArgs e) //el metodo debe coincir don el delegado
        {
        }
            //De la siguiente forma se puede suscribir al evento pero en la definición
            //del metodo suscrito en la linea 28 no pude ser "static"
            //      RaisingAnEvent rae = new RaisingAnEvent();
            //      instancia.nombreevento += rae.netodo;
            //De esta forma la suscripción si puede ser a un metodo "static" de la linea 28
            intancia.evento += new CLASE.delegado(metoo);

*/





using System;

namespace _144
{
    class Program
    {
        static void Main(string[] args)
        {
            Loan loan = new Loan();
 

            //De la siguiente forma se puede suscribir al evento pero en la definición
            //del metodo suscrito en la linea 28 no pude ser "static"
            //      RaisingAnEvent rae = new RaisingAnEvent();
            //      loan.OnMaximunTermReached += rae.ControldeTemperatura;
            //De esta forma la suscripción si puede ser a un metodo "static" de la linea 28
            loan.OnMaximunTermReached += new Loan.ControldeTemperaturaHandler(ControldeTemperatura);
            loan.Term = 5;
            Console.WriteLine (loan.Term);
            loan.Term = 20;
            Console.ReadLine();
 }
        public static void ControldeTemperatura(Loan cof, EventArgs e)
        {
            PersonalArgs p = (PersonalArgs) e;
            Console.WriteLine($"Carga no permitida {p.valor}");
            Console.ReadLine();
        }

    }

   public class PersonalArgs : EventArgs
   {
       public int valor {get;set;}
       public PersonalArgs(int valor) : base()
       {
           this.valor = valor;
       }
   }
    
    public class Loan {
        // eventos y delegados
        public event ControldeTemperaturaHandler OnMaximunTermReached;
        public delegate void ControldeTemperaturaHandler (Loan source, EventArgs e);
        // fields y propiedades
        private int _term;
	    private const int MaximumTerm = 10;
	    private const decimal Rate = 0.034m;
        public int Term
        {
            get 
            {
                return _term;
            }
            set
            {
                if (value <= MaximumTerm)
                {
                    _term = value;
                }
                else
                {
                    if (OnMaximunTermReached != null)
                        OnMaximunTermReached (this, new PersonalArgs(value));

                }
            }
        }
    }







  

}
