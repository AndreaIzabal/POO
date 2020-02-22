using System;

namespace Peliculas
{
<<<<<<< HEAD
     class Peliculas
    {
        public string Titulo;
        public int Año;
=======
    class Peliculas
    {
        public string titulo;
        public int16 año;
>>>>>>> 9f41e708d1dbfa591963f71fd39953603275b680
        public string pais;
        public string director;
        
        //Constructor
<<<<<<< HEAD
        public Peliculas()
        {
         
        }
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
=======
        public Pelicula(string T, int16 a )
        {
         
        }


    }
>>>>>>> 9f41e708d1dbfa591963f71fd39953603275b680
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
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
=======
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

>>>>>>> 9f41e708d1dbfa591963f71fd39953603275b680
