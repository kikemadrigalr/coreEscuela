using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi School", 2012);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogotá";
            escuela.TipoEscuela = TiposEscuela.Primaria;
            Console.WriteLine(escuela);

            var escuela2 = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad:"Bogotá");
            Console.WriteLine(escuela2);

            //arreglos
            var arregloCursos = new Curso[3];

            // var curso1 = new Curso(){
            //     Nombre = "101"
            // };

            arregloCursos[0] = new Curso(){Nombre = "101"};

            var curso2 = new Curso(){
                Nombre = "201"
            };

            arregloCursos[1] = curso2;

            // var curso3 = new Curso(){
            //     Nombre = "301"
            // };

            arregloCursos[2] = new Curso{ Nombre = "301"};

            

            Console.WriteLine("=========CURSOS========");
            // Console.WriteLine($"Curso: {curso1.Nombre} - {curso1.UniqueId}");
            // Console.WriteLine($"Curso: {curso2.Nombre} - {curso2.UniqueId}");
            // Console.WriteLine($"Curso: {curso3.Nombre} - {curso3.UniqueId}");
            ImprimirCursosWhile(arregloCursos);
            Console.WriteLine("=================");
            ImprimirCursosDoWhile(arregloCursos);
            Console.WriteLine("=================");
            ImprimirCursosFor(arregloCursos);
            Console.WriteLine("=================");
            ImprimirCursosForEach(arregloCursos);
            
        }

    private static void ImprimirCursosWhile(Curso[] arregloCursos)
    {
      int i = 0;
      while (i < arregloCursos.Length)
      {
        Console.WriteLine($"Curso: {arregloCursos[i].Nombre}, ID: {arregloCursos[i].UniqueId}");
        i++;
      };
    }


    private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
    {
      int i = 0;
      do
      {
        Console.WriteLine($"Curso: {arregloCursos[i].Nombre}, ID: {arregloCursos[i].UniqueId}");
        i++;
      }while (i < arregloCursos.Length);
    }

     private static void ImprimirCursosFor(Curso[] arregloCursos)
    {
      for (int i = 0; i < arregloCursos.Length; i++)
      {
        Console.WriteLine($"Curso: {arregloCursos[i].Nombre}, ID: {arregloCursos[i].UniqueId}");
      }
    }

    private static void ImprimirCursosForEach(Curso[] arregloCursos)
    {
      foreach (var curso in arregloCursos)
      {
        Console.WriteLine($"Curso: {curso.Nombre}, ID: {curso.UniqueId}");
      }
    }


  }
}
