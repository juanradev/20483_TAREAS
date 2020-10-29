using System;
using static System.Console;


namespace _177
{

    class Program
    {
        
        static void Main(string[] args)
        {
           
           WriteLine( Find(1 ));
           WriteLine(Find(null)); // si llamamos con null nos lanza excepcion
           //WriteLine(Find("cadena" ));
           WriteLine(Find(null,"cadena" ));
           WriteLine(Find(5,"cadena" ));
         }
         public static Elemento Find(int id ){
            return ( new Elemento(1,"elemento 1, metodo  Elemento Find(int id )")) ;
 
        }
         public static Elemento Find(int? id ){
            return ( new Elemento(2,"elemento 2, metodo  Elemento Find(int? id  )")) ;
        }
     /*   public static Elemento Find(string name){
            return ( new Elemento(3,"elemento 3, metodo  Elemento Find(string name )")) ;
        }*/
        public static Elemento Find(int? id, string name){
            return ( new Elemento(4,"elemento 4, metodo  Elemento Find(int? id, string name)")) ;
        }
         public static Elemento Find(int  id, string name){
            return ( new Elemento(5,"elemento 5, metodo  Elemento Find(int id, string name)")) ;
        }


    }
    public class Elemento
    {
        public int id {get; set;}
        public string name {get; set;}
        public Elemento( int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public override string ToString(){
            return $"{this.id} {this.name}";
        }
    }

       
}

     

  


     
