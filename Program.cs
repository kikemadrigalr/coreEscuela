using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using CoreEscuela.Entidades;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
          var engine = new EscuelaEngine();
          
          engine.Inicializar();
          ImprimirCursosEscuela(engine.Escuela);
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

  }
}
