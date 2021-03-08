using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
          var engine = new EscuelaEngine();
          
          engine.Inicializar();
          // Printer.DibujarLinea(20);
          Printer.DibujarTitulo("BIENVENIDOS A LA ESCUELA");
          Printer.Timbrar(880,1000);
          Printer.Timbrar(1046,2000);
          ImprimirCursosEscuela(engine.Escuela);
        }

    private static void ImprimirCursosEscuela(Escuela escuela){
      // WriteLine("========================");
      // WriteLine("==Cursos de la Escuela==");
      // WriteLine("========================");

      Printer.DibujarTitulo("CURSOS DE LA ESCUELA");

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
