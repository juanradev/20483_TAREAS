using System;
namespace _83
{
    class Program
    {
        static void Main(string[] args)
        {
            Game juego1 = new Game();
            Game juego2 = new Game();
            juego1.score=3;
            juego2.score=5;
            Game.scorestatic = 13;
            Console.WriteLine (juego1.score);
            Console.WriteLine (juego2.score);
            Console.WriteLine (Game.scorestatic);
        }
    }
    public class Game 
    {
        private int _score;
        public int score {
            get { return _score;}
            set { _score=(value >0) ? value : 0;}
        }  
         public static int scorestatic { get; set; }  
    }
}
 