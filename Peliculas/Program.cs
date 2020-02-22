using System;

namespace Peliculas
{
    class Peliculas
    {
        public string Titulo;
        public int Año;
        public string Pais;
        public string Director;
        
         public Peliculas GetTitulo(string T, int A)
         {
             Titulo= T;
             return T;

             Año=A;
             return Año;
         }
         public Peliculas SetTitulo( string T)
         {
             Titulo= T;
             return T;
         }
    
         public Peliculas SetAño(int A)
         {
             Año=A;
             return A;
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
