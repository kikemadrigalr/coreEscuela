﻿using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using CoreEscuela.Entidades;
using static System.Console;
using CoreEscuela.Util;
using System.Linq;
using CoreEscuela.App;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
          //Manejo de eventos 
          //CurrentDomain representa el lugar donde se este ejecutando la aplicacion
          //se utiliza el operador += para asignar el apuntador del evento
          //ProcessExit Indica que el evento se va a ejecutar cuando se cierre la aplicacion
          // AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
          //otra forma de agregar un evento usando expresiones lamda
          //multicast delegate, es un manejador de eventos que recibe muchos delegados
          // AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Timbrar(440,1000,1);

          //eliminar un delegado del manejador de eventos con -=
          //AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento;

          // AppDomain: funcionalidad interna del framework, es donde se ejecutan cada una de las aplicaciones en un momento determinado.
          // CurrentDomain: donde se ejecuta el programa específicamente.
          // Evento: dispara varias accciones en un momento determinado  
          // ProcessExit: se dispara cada vez que la aplicacion finaliza de forma normal y no abruta.



          var engine = new EscuelaEngine();
          
          engine.Inicializar();
          Printer.DibujarTitulo($"BIENVENIDOS A LA ESCUELA {engine.Escuela.Nombre}");
          mostrarDatosEscuela(engine.Escuela);

          var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
          var evalList = reporteador.GetListaEvaluaciones();
          var listaAsign = reporteador.GetListaAsignaturas();
          var listaEvaluacionAsignatura = reporteador.GetDiccEvalAsignaturas();
          var promediosAsignatura = reporteador.GetPromedioAlumnosAsignatura();
          
          //esto cerraria el programa y ejecutaria el evento()
          // return;

          // Printer.Timbrar(880,1000);
          // Printer.Timbrar(1046,2000);
          // ImprimirCursosEscuela(engine.Escuela);
          //ImprimirInformacionCursosAlumnos(engine.Escuela);
          //ImprimirInformacionAlumnosEvaluaciones(engine.Escuela);

          //como la clase ObjetoEscuelaBase es abstracta no se puede instanciar
          // var obj = new ObjetoEscuelaBase();
          // Printer.DibujarLinea(50);
          // Printer.DibujarTitulo("Pruebas de Polimorfismo");

          var alumnoTest = new Alumno(){Nombre = "Tony Stark"};

          // Printer.DibujarTitulo("Alumno");
          // WriteLine($"Alumno: {alumnoTest.Nombre}");
          // WriteLine($"Alumno: {alumnoTest.UniqueId}");
          // WriteLine($"Alumno: {alumnoTest.GetType()}");

          ObjetoEscuelaBase ob = alumnoTest;
          // Printer.DibujarTitulo("Objeto Escuela Base");
          // WriteLine($"Alumno: {ob.Nombre}");
          // WriteLine($"Alumno: {ob.UniqueId}");
          // WriteLine($"Alumno: {ob.GetType()}");

          //Clase abstracta por lo tanto no se puede instanciar
          // var objetoDummy = new ObjetoEscuelaBase(){Nombre = "Steve Rogers"};
          // Printer.DibujarTitulo("Objeto Dummy Escuela Base");
          // WriteLine($"Alumno: {objetoDummy.Nombre}");
          // WriteLine($"Alumno: {objetoDummy.UniqueId}");
          // WriteLine($"Alumno: {objetoDummy.GetType()}");

          //Aunque ambos heredan de objetoEscuela
          //el cmpilador detecta que son tipos diferentes
          //Con el casting el compilador entiende que son similares pero falla al momento de ejecutar
          // alumnoTest = (Alumno)objetoDummy;
          Printer.DibujarTitulo("Objeto Alumno");
          // WriteLine($"Alumno: {alumnoTest.Nombre}");
          // WriteLine($"Alumno: {alumnoTest.UniqueId}");
          // WriteLine($"Alumno: {alumnoTest.GetType()}");

          var evaluacion = new Evaluacion(){Nombre = "Evaluacion MAth", Nota=4.5f};
          // Printer.DibujarTitulo("Evaluacion");
          // WriteLine($"Evaluacion: {evaluacion.Nombre}");
          // WriteLine($"Evaluacion: {evaluacion.UniqueId}");
          // WriteLine($"Evaluacion: {evaluacion.Nota}");
          // WriteLine($"Evaluacion: {evaluacion.GetType()}");

          // ob = evaluacion;
          // Printer.DibujarTitulo("Objeto Escuela");
          // WriteLine($"Alumno: {ob.Nombre}");
          // WriteLine($"Alumno: {ob.UniqueId}");
          // WriteLine($"Alumno: {ob.GetType()}");

          //Intento de hacer castin para convertir evaluacion en alumno
          //falla en momento de compilacion
          // alumnoTest = (Alumno)(ObjetoEscuelaBase)evaluacion;

          //validar que un objeto es de un tipo especifico con (is, as)
          //is
          if(ob is Alumno){
            var alumnoRecuperado = (Alumno)ob;
          }

          //as
          // si ob lo puede recuperar como alumno lo hace y la asigna
          //sino devuelve null
          var alumnoRecuperado2 = ob as Alumno;

          if(alumnoRecuperado2 != null){
            WriteLine("Datos del Alumno");

          }

          // engine.Escuela.LimpiarLugar();
          

          //para ejecutar una funcion con parametros de salida, 
          //siempre deben marcarse cuales son los parametros de salida con la palabra reservada out
          //para evitar pasar todos los parametros de salida, se puede pasar una variable dummy
          //como señuelo para el metodo pero indica que no retornara nada
          // int dummy = 0;
          // var ListaObjetosEscuela = engine.getObjetosEscuela(
          //   out int conteoEvaluaciones, out int conteoAlumnos, out int conteoAsignaturas, out int conteoCursos
          //   );
          // var ListaObjetosEscuela = engine.getObjetosEscuela(());


          //obtener lista de objetos que implementen la interfaz ILugar con Linq
          //utilizando (is para especificar que se buscan objetos tipo ILugar)
          //y casting para ver los objetos obtenidos como ILugar
          // var listaIlugar = from obj in ListaObjetosEscuela
          //                   where obj is ILugar
          //                   select (ILugar)obj ; 
          
           //TRABAJAR CON DICCIONARIOS
            // Dictionary<int, string> diccionario = new Dictionary<int, string>();

            // //agregar elementos al diccionario
            // diccionario.Add(7, "KIKEMADRIGAL");
            // diccionario.Add(23, "DUALIPA");

            // //recorrer diccionarios
            // //Las llaves de los diccionarios no pueden repetirse
            // foreach (var keyValPair in diccionario)
            // {
            //   WriteLine($"Llave: {keyValPair.Key}, Valor: {keyValPair.Value}");
            // }

            // Printer.DibujarTitulo("Acceso a Diccionarios");
            // diccionario[0] = "Harley Queen";
            // WriteLine(diccionario[23]);
            // WriteLine(diccionario[0]);

            // Printer.DibujarTitulo("Otro Diccionario");
            // var dicc = new Dictionary<string, string>();
            // dicc["Luna"] = "Cuerpo Celeste que gira al rededor de la tierra";
            // WriteLine(dicc["Luna"]);
            // dicc["Luna"] = "Protagonista de Soy Luna";
            // WriteLine(dicc["Luna"]);

            var dictem = engine.GetDiccionarioObjetos();
            engine.ImprimirDiccionario(dictem);

        }

    private static void AccionDelEvento(object sender, EventArgs e)
    {
      Printer.DibujarTitulo("Saliendo");
      Printer.Timbrar(880, 1000, 3);
      Printer.DibujarTitulo("Saliò");
    }

    #region Mostrar Informacion Escuela
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
    #endregion

  }
}
