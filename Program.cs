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
          Printer.DibujarTitulo($"BIENVENIDOS A LA ESCUELA {engine.Escuela.Nombre}");
          mostrarDatosEscuela(engine.Escuela);
          // Printer.Timbrar(880,1000);
          // Printer.Timbrar(1046,2000);
          ImprimirCursosEscuela(engine.Escuela);
          ImprimirInformacionCursosAlumnos(engine.Escuela);
          ImprimirInformacionAlumnosEvaluaciones(engine.Escuela);

          //como la clase ObjetoEscuelaBase es abstracta no se puede instanciar
          // var obj = new ObjetoEscuelaBase();
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

    private static void ImprimirInformacionCursosAlumnos(Escuela escuela){
      if(escuela?.Cursos != null){
        foreach (var curso in escuela.Cursos)
        {
          Printer.DibujarTitulo($"Curso: {curso.Nombre}");
          WriteLine("Lista de Asignaturas del Curso");
          Printer.DibujarLinea(30);
          foreach (var asignatura in curso.Asignaturas)
          {
            WriteLine($"- {asignatura.Nombre}");
          }

          Printer.DibujarLinea(50);
          WriteLine("Lista de Alumnos del Curso");
          foreach (var alumno in curso.Alumnos)
          {
            WriteLine($"- {alumno.Nombre}");
          }
        }
      }
    }

    private static void ImprimirInformacionAlumnosEvaluaciones(Escuela escuela){
      if(escuela?.Cursos != null){
        foreach (var curso in escuela.Cursos)
        {
          Printer.DibujarTitulo($"Evaluaciones del Curso {curso.Nombre}");
          foreach (var alumno in curso.Alumnos)
          {
            WriteLine($"***** Alumno: {alumno.Nombre} *****");
            Printer.DibujarLinea(50);
              foreach (var evaluacion in alumno.Evaluaciones)
              {
                WriteLine($"- {evaluacion.Nombre} - {evaluacion.Nota}");

              }
            Printer.DibujarLinea(50);
            Printer.DibujarLinea(50);
          }
        }
      }
    }
  }
}
