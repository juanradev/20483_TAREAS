<<<<<<< HEAD
﻿using System;
using System.Runtime.CompilerServices;

namespace jemplowriteline
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrizLetra letraÑ = new MatrizLetra('Ñ');
            MatrizLetra letraY = new MatrizLetra('Y');
            letraÑ.pintar();
            letraY.pintar();
            Console.ReadKey();
        }

       

    }

   public class MatrizLetra
    {
        private char letra { get; set; }
        private char [,] matriz { get; set; }

        public MatrizLetra(char letra)
        {
            this.letra = letra;
            matriz = new char[7,7];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    matriz[i, j] = ' ';


            switch (letra)
            {
                case 'Ñ':
                    crearenne(); break;
                case 'Y':
                    creary(); break;
            }
        }

        public void crearenne()
        {
            
            for (int i = 0; i < 7; i++)
            {
                matriz[0, i] = '*';
            }
            for (int i = 2; i <7 ; i++)
            {
                matriz[i, 0] = '*';
                matriz[i, 6] = '*';
            }
            matriz[2, 1] = '*';
            matriz[3, 2] = '*';
            matriz[4, 3] = '*';
            matriz[5, 4] = '*';
            matriz[6, 5] = '*';
        }


        public void creary()
        {

            matriz[0, 0] = '*';
            matriz[1,1] = '*';
            matriz[2,2] = '*';
            matriz[3,3] = '*';
            matriz[2,4] = '*';
            matriz[1,5] = '*';
            matriz[0,6] = '*';
            for (int i = 3; i<7; i++)
                matriz[i, 3] = '*';


        }

        public void pintar()
        {
            
            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 7; j++)
                    Console.Write(matriz[i, j]);
            }
            Console.WriteLine(); 
            Console.WriteLine($"esto es una letra {this.letra}");
        }


    }
}
=======
﻿using System;
using System.Runtime.CompilerServices;

namespace jemplowriteline
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrizLetra letraÑ = new MatrizLetra('Ñ');
            MatrizLetra letraY = new MatrizLetra('Y');
            letraÑ.pintar();
            letraY.pintar();
            Console.ReadKey();
        }

       

    }

   public class MatrizLetra
    {
        private char letra { get; set; }
        private char [,] matriz { get; set; }

        public MatrizLetra(char letra)
        {
            this.letra = letra;
            matriz = new char[7,7];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    matriz[i, j] = ' ';


            switch (letra)
            {
                case 'Ñ':
                    crearenne(); break;
                case 'Y':
                    creary(); break;
            }
        }

        public void crearenne()
        {
            
            for (int i = 0; i < 7; i++)
            {
                matriz[0, i] = '*';
            }
            for (int i = 2; i <7 ; i++)
            {
                matriz[i, 0] = '*';
                matriz[i, 6] = '*';
            }
            matriz[2, 1] = '*';
            matriz[3, 2] = '*';
            matriz[4, 3] = '*';
            matriz[5, 4] = '*';
            matriz[6, 5] = '*';
        }


        public void creary()
        {

            matriz[0, 0] = '*';
            matriz[1,1] = '*';
            matriz[2,2] = '*';
            matriz[3,3] = '*';
            matriz[2,4] = '*';
            matriz[1,5] = '*';
            matriz[0,6] = '*';
            for (int i = 3; i<7; i++)
                matriz[i, 3] = '*';


        }

        public void pintar()
        {
            
            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 7; j++)
                    Console.Write(matriz[i, j]);
            }
            Console.WriteLine(); 
            Console.WriteLine($"esto es una letra {this.letra}");
        }


    }
}
>>>>>>> 108a206a453ce0e16063ab50fba7601885ef47c1
