using System;

namespace Peliculas
{
    class Peliculas
    {
        public string titulo;
        public int16 año;
        public string pais;
        public string director;
        
        //Constructor
        public Pelicula(string T, int16 a )
        {
         
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
         Pelicula p1 = new Pelicula();
         p1.SetTitulo("La La Land");
         p1.SetAño(2016); 
         Console.WriteLine("{0}({1})", p1.GetTitulo(), p1.GetAño());
         Pelicula p2 = new pelicula();
         p2.SetTitulo("Frozen");
         p2.SetAño(2016);
         Console.WriteLine("{0}({2})"),p2.GetTitulo().p2.GetAño());
 
        }
    }
}

