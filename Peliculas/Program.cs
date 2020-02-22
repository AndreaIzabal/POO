using System;

namespace Peliculas
{
    class Peliculas
    {
        public string Titulo;
        public int Año;
        public string Pais;
        public string Director;
        
         public string GetTitulo()
         {
             return Titulo;
         }
         public string SetTitulo()
         {
             return Titulo;
         }
         public int GetAño()
         {
             return Año;
         }
         public int SetAño()
         {
             return Año;
         }

    }
    class Program
    {
        static void Main(string[] args)
        {
         Peliculas p1 = new Peliculas();
         p1.SetTitulo("La La Land");
         p1.SetAño(2016); 
         Console.WriteLine("{0}({1}");
         p1.GetTitulo();
         p1.GetAño();
         Peliculas p2 = new Peliculas ();
         p2.SetTitulo("Frozen");
         p2.SetAño(2016);
         Console.WriteLine("{0}({2})");
         p2.GetTitulo();
         p2.GetAño();
        }
    }
}
