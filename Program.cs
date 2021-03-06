using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using CoreEscuela.Entidades;
using static System.Console;

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

            //manejar cursos utilizando colecciones
            escuela.Cursos = new List<Curso>(){
              new Curso(){Nombre = "101"},
              new Curso(){Nombre = "201"},
              new Curso(){ Nombre = "301"}
            };

            //Agregar miembros a una coleccion
            escuela.Cursos.Add( new Curso(){ Nombre = "102", Jornada = TiposJornada.Tarde});
            escuela.Cursos.Add( new Curso(){ Nombre = "202", Jornada = TiposJornada.Tarde});

            var otraColeccion = new List<Curso>(){
              new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
              new Curso(){Nombre = "401", Jornada = TiposJornada.Mañana},
              new Curso(){ Nombre = "502", Jornada = TiposJornada.Tarde}
            };

            //eliminar todos los elementos de una coleccion
            // otraColeccion.Clear();

            //Eliminar solo un elemento de la coleccion
            // escuela.Cursos.Remove();

            //addRange agrega una collecion creada anteriormente como parte de na coleccion definida
            escuela.Cursos.AddRange(otraColeccion);

            ImprimirCursosEscuela(escuela);

            // arregloCursos[0] = new Curso(){Nombre = "101"};
            // var curso2 = new Curso(){ Nombre = "201"};
            // arregloCursos[1] = curso2;
            // arregloCursos[2] = new Curso{ Nombre = "301"};

            

            // Console.WriteLine("=========CURSOS========");
            // Console.WriteLine($"Curso: {curso1.Nombre} - {curso1.UniqueId}");
            // Console.WriteLine($"Curso: {curso2.Nombre} - {curso2.UniqueId}");
            // Console.WriteLine($"Curso: {curso3.Nombre} - {curso3.UniqueId}");
            // ImprimirCursosWhile(arregloCursos);
            // Console.WriteLine("=========Do While==========");
            // ImprimirCursosDoWhile(arregloCursos);
            // Console.WriteLine("==========For==========");
            // ImprimirCursosFor(arregloCursos);
            // Console.WriteLine("==========For Each=======");
            // ImprimirCursosForEach(arregloCursos);
            
        }

    private static void ImprimirCursosEscuela(Escuela escuela){
      WriteLine("========================");
      WriteLine("==Cursos de la Escuela==");
      WriteLine("========================");

      // if (escuela != null && escuela.Cursos != null)
      if(escuela?.Cursos != null)
      {
        foreach (var curso in escuela.Cursos)
        {
          Console.WriteLine($"Curso: {curso.Nombre}, ID: {curso.UniqueId}");
        }
      }
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
