using System;
using System.Reflection;
using System.Collections;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela
{
  //sealed indica que la clase puede ser instanciada pero no se puede heredar de ella en otra clase
  public sealed class EscuelaEngine
  {
    public Escuela Escuela { get; set; }
    
    public EscuelaEngine()
    {
      
    }

    public void Inicializar()
    {
      Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, pais:"Colombia", ciudad:"Bogotá");

      CargarCursos();
      CargarAsignaturas();
      CargarEvaluaciones();
      // var ObjetosEscuela = getObjetosEscuela();
    }

#region Lista Objestos de la escuela

//reesribiendo metodo para utilizar parametros opciones y definir parametros de salida
public List<ObjetoEscuelaBase> getObjetosEscuela(
  out int conteoEvaluaciones, out int conteoAlumnos, out int conteoAsignaturas, out int conteoCursos,
  bool traerEvaluaciones = true, bool traerAlumnos = true, bool traerAsignaturas = true, bool traerCursos = true
  ){
    var listaObjetos = new List<ObjetoEscuelaBase>();
    conteoAlumnos = conteoAsignaturas =  conteoEvaluaciones = 0;

    listaObjetos.Add(Escuela);

    if(traerCursos)
      listaObjetos.AddRange(Escuela.Cursos);

    conteoCursos = Escuela.Cursos.Count;
    foreach (var curso in Escuela.Cursos)
    {
      conteoAsignaturas += curso.Asignaturas.Count;
      conteoAlumnos += curso.Alumnos.Count;

      if(traerAsignaturas)
        listaObjetos.AddRange(curso.Asignaturas);

      if(traerAlumnos)
        listaObjetos.AddRange(curso.Alumnos);

      if (traerEvaluaciones)
      {
        foreach (var alumno in curso.Alumnos)
        {
          listaObjetos.AddRange(alumno.Evaluaciones);
          conteoEvaluaciones += alumno.Evaluaciones.Count;
        }
      }
      
    }
        
    return listaObjetos;
  }



//reescribiendo el metodo getObjetosEscuela para utilizar parametros opcionales dependiendo de los objetos que quiero recuperar
//y definir parametros de salida para que devuelva mas de un objeto
  // public (List<ObjetoEscuelaBase>, int) getObjetosEscuela(bool traerEvaluaciones = true, bool traerAlumnos = true, bool traerAsignaturas = true, bool traerCursos = true){
  //   var listaObjetos = new List<ObjetoEscuelaBase>();
  //   int conteoEvaluaciones = 0;

  //   listaObjetos.Add(Escuela);

  //   if(traerCursos)
  //     listaObjetos.AddRange(Escuela.Cursos);

  //   foreach (var curso in Escuela.Cursos)
  //   {
  //     if(traerAsignaturas)
  //       listaObjetos.AddRange(curso.Asignaturas);

  //     if(traerAlumnos)
  //       listaObjetos.AddRange(curso.Alumnos);

  //     if (traerEvaluaciones)
  //     {
  //       foreach (var alumno in curso.Alumnos)
  //       {
  //         listaObjetos.AddRange(alumno.Evaluaciones);
  //         conteoEvaluaciones += alumno.Evaluaciones.Count;
  //       }
  //     }
      
  //   }
        
  //   return (listaObjetos, conteoEvaluaciones);
  // }
      // public List<ObjetoEscuelaBase> getObjetosEscuela(){
      //   var listaObjetos = new List<ObjetoEscuelaBase>();

      //   listaObjetos.Add(Escuela);
      //   listaObjetos.AddRange(Escuela.Cursos);

      //   foreach (var curso in Escuela.Cursos)
      //   {
      //     listaObjetos.AddRange(curso.Asignaturas);
      //     listaObjetos.AddRange(curso.Alumnos);

      //     foreach (var alumno in curso.Alumnos)
      //     {
      //       listaObjetos.AddRange(alumno.Evaluaciones);
      //     }
      //   }
        
      //   return listaObjetos;
      // }
#endregion

#region Metodos de Carga
      private void CargarCursos(){
        Escuela.Cursos = new List<Curso>(){
          new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana},
          new Curso(){ Nombre = "201", Jornada = TiposJornada.Mañana},
          new Curso(){ Nombre = "301", Jornada = TiposJornada.Mañana},
          new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde},
          new Curso(){ Nombre = "501", Jornada = TiposJornada.Tarde}
        };

        //agregar los alumnos a cada curso
        foreach (var c in Escuela.Cursos)
        {
          //generar cantidades aleatorias con Random y Next
          Random rnd = new Random();
          int cantRandom = rnd.Next(5, 20);
          c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
        };
      }

      private List<Alumno> GenerarAlumnosAlAzar(int cantidad){
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        //asignacion de los nombre utilizando linq
        var listaAlumnos =  from n1 in nombre1
                            from n2 in nombre2
                            from a1 in apellido1
                            select new Alumno(){ Nombre = $"{n1} {n2} {a1}"};

        return listaAlumnos.OrderBy(alum => alum.UniqueId).Take(cantidad).ToList();
      }

      private void CargarAsignaturas(){
        foreach (var curso in Escuela.Cursos)
        {
          List<Asignatura> listaAsignaturas = new List<Asignatura>(){
            new Asignatura{ Nombre = "Matemáticas" },
            new Asignatura{ Nombre = "Educación Física" },
            new Asignatura{ Nombre = "Castellano" },
            new Asignatura{ Nombre = "Ciencias Naturales" }
          };

          curso.Asignaturas = listaAsignaturas;
        };
      }
      
      private void CargarEvaluaciones(){
        int evaluacionesTotales = 5;
        string[] prueba = { "Parcial", "Final", "Preparatorio", "Quiz", "Acumulativo", "Práctico"};

        Random rnd = new Random();
        Random nota = new Random();

        foreach (var curso in Escuela.Cursos)
        {
          foreach (var asignatura in curso.Asignaturas)
          {
            foreach (var alumno in curso.Alumnos)
            {
              for (int i = 0; i < evaluacionesTotales; i++)
              {
                int numNombre = rnd.Next(0, 6);

                var evaluacion = new Evaluacion() { 
                  Nombre = $"{prueba[numNombre] }" + " " + $"{asignatura.Nombre}", 
                  // Nombre = $"{asignatura.Nombre} - Evaluacion {prueba[numNombre]}",
                  Alumno = alumno,
                  Asignatura = asignatura,
                  Nota = Math.Round(nota.NextDouble() * 5, 2) 
                };

                alumno.Evaluaciones.Add(evaluacion);
              }
            }
          }
        }
      }
#endregion
  }
}