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
          var cursosEscuela = new Curso();
          
          engine.Inicializar();
          // Printer.DibujarLinea(20);
          Printer.DibujarTitulo("BIENVENIDOS A LA ESCUELA");
          mostrarDatosEscuela(engine.Escuela);
          Printer.Timbrar(880,1000);
          Printer.Timbrar(1046,2000);
          ImprimirCursosEscuela(engine.Escuela);

          ImprimirAsignaturasCursos(engine.Escuela);

          // ImprimirEvaluacionesCurso();
        }

        private static void mostrarDatosEscuela(Escuela escuela){
          if(escuela != null)
          {
            WriteLine(escuela);
          }
        }

    private static void ImprimirCursosEscuela(Escuela escuela){

      Printer.DibujarTitulo("CURSOS DE LA ESCUELA");

      if(escuela?.Cursos != null)
      {
        foreach (var curso in escuela.Cursos)
        {
          Console.WriteLine($"Curso: {curso.Nombre}, ID: {curso.UniqueId}");
        }
      }
    }

    private static void ImprimirAsignaturasCursos(Escuela escuela){
      Printer.DibujarTitulo("Asignaturas de los Cursos");
    }

  }
}
