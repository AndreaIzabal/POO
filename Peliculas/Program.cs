using System;

namespace Peliculas
{
    class Peliculas
    {
        public string titulo;
        public int año;
        public string pais;
        public string director;


    }
    class Program
    {
        static void Main(string[] args)
        {
         Pelicula p1 = new Pelicula();
         p1.SetTitulo("La La Land");
         p1.SetAño(2016); 
         Console.WriteLine("{0}({1})", p1.GetTitulo(), p1.GetAño());
 
        }
    }
}
