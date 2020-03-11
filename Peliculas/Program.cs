using System.Collections.Generic;
using System.Collections;
using System;

namespace Peliculas
{
    class Peliculas
    {
        public Peliculas (){}
        public string Titulo;
        public Int16 Año;
        public string Pais;
        public string Director;
        public string Actor;
        
         public void SetTitulo(string Titulo)
         {
             this.Titulo= Titulo;
         }
         public string GetTitulo() => Titulo; 
         public void SetAño(Int16 Año)
         {
             this.Año=Año;
         }
         public Int16 GetAño() => Año;
         public void SetPais(string Pais)
         {
             this.Pais=Pais;
         }
         public string GetPais() => Pais;
         public void SetDirector(string Director)
         {
             this.Director=Director;
         }
         public string GetDirector() => Director;
          public void AgregarActor(string Actor)
         {
             this.Actor= Actor;
         }
         public string AgregarActor()=> Actor;
         

    }
    class Program
    {
        static void Main(string[] args)
        {
         Peliculas p1 = new Peliculas();
         p1.SetTitulo("Green Book");
         p1.SetAño(2016);
         p1.SetPais("EEUU");
         p1.SetDirector( "Peter Farrelly");
         p1.AgregarActor("Viggo Mortensen");
         Console.WriteLine( "{0} {1} {2} {3} {4}", p1.GetTitulo(), p1.GetAño(),  p1.GetPais() ,p1.GetDirector(), p1.AgregarActor());
         
         Peliculas p2 = new Peliculas();
         p2.SetTitulo("Bohemian Rhapsody");
         p2.SetAño(2016);
         p2.SetPais("EEUU");
         p2.SetDirector( "Bryan Singer");
         p2.AgregarActor("Rami Malek");
         Console.WriteLine( "{0} {1} {2} {3} {4}", p2.GetTitulo(), p2.GetAño(),  p2.GetPais() ,p2.GetDirector(), p1.AgregarActor());

        List<Peliculas> lista = new List<Peliculas>();
        lista.Add(p1);
        lista.Add(p2);

        foreach(Peliculas movie in lista)
        {
            Console.WriteLine(movie.Titulo);
        }
        }
    }
}  
