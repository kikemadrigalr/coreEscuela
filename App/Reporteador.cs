using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;

        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjetosEscuela)
        {
            if(dicObjetosEscuela == null){
                throw new ArgumentException(nameof(dicObjetosEscuela));
            }
            _diccionario = dicObjetosEscuela;
        }

        //metodo reporte con la lista de Evaluaciones
        // public IEnumerable<Escuela> GetListaEvaluaciones(){
        //     IEnumerable<Escuela> listaRetorno;

        //     var respta = _diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista);

        //     if(respta == true){
        //         listaRetorno = lista.Cast<Escuela>();
        //     }else{
        //         listaRetorno = null;
        //         //Por ejemplo escribir log de auditoria en caso de no obtener datos
        //     }

        //     return listaRetorno;
        // }

         public IEnumerable<Evaluacion> GetListaEvaluaciones(){
            var respta = _diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista);

            if(respta == true){
                return lista.Cast<Evaluacion>();
            }else{
                return new List<Evaluacion>();
            }
        }

        //obtener Lista de asignaturas
        
        //sobrecarga del metodo para obtener lista de asignaturas, este servira para ejecutarse cuando 
        //no queremos pasar el parametro de salida, es decir no devolvera la lista de evaluaciones
        public IEnumerable<String> GetListaAsignaturas(){
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<String> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones){
           listaEvaluaciones = GetListaEvaluaciones();

            //usando Linq
           return (from Evaluacion ev in listaEvaluaciones
                  select ev.Asignatura.Nombre).Distinct();
        }

        //obtener Lista (diccionario) de evaluaciones por asignaturas
        public Dictionary<String, IEnumerable<Evaluacion>> GetDiccEvalAsignaturas(){
            var DiccResp = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsignaturas = GetListaAsignaturas(out var listaEvaluaciones);

            foreach (var asignat in listaAsignaturas)
            {
                //query linq para obtener la evaluaciones de cada asignatura
                var evalsAsignatura = from evaluacion in listaEvaluaciones
                                  where evaluacion.Asignatura.Nombre == asignat
                                  select evaluacion;

                DiccResp.Add(asignat, evalsAsignatura);
            }

            return DiccResp;
        }

        //metodo para generar una lista del promedio de cada alumno que esta registrado en la asignatura
        //Asignatura : Lista de alumnos : Promedio
        //utilizando LinQ
        public Dictionary<String, IEnumerable<AlumnoPromedio>> GetPromedioAlumnosAsignatura(){
            var resp = new Dictionary<String, IEnumerable<AlumnoPromedio>>();

            //obtener lista de evaluaciones por asignaturas
            var dicEvaluacionesAsignaturas = GetDiccEvalAsignaturas();

            //rrecores las llaves del diccionario (asignaturas) para obtener las evaluaciones de cada una
            foreach (var asignConEvaluacion in dicEvaluacionesAsignaturas)
            {
                var promediosAlumnos = from evaluacion in asignConEvaluacion.Value
                            group evaluacion by new {
                                evaluacion.Alumno.UniqueId,
                                evaluacion.Alumno.Nombre
                            } 
                            into grupoEvalsAlumno
                            select new AlumnoPromedio{ 
                                // evaluacion.Alumno.UniqueId,
                                // NombreAlumno = evaluacion.Alumno.Nombre,
                                // NombreEvaluacion = evaluacion.Nombre,
                                // evaluacion.Nota
                                alumnoId = grupoEvalsAlumno.Key.UniqueId,
                                promedio = grupoEvalsAlumno.Average(eval => Math.Round(eval.Nota,2)),
                                alumnoNombre = grupoEvalsAlumno.Key.Nombre
                                };
                                //se crea un objeto compuesto, del tipo anonimo usando la palabra reservada new
                                //permite devover un objeto que nunca he creado
                                resp.Add(asignConEvaluacion.Key, promediosAlumnos);
            }

            return resp;
        }
        public Dictionary<String, IEnumerable<AlumnoPromedio>> GetTopPromedios(int top){
            var resp = new Dictionary<String, IEnumerable<AlumnoPromedio>>();
            var diccPromedios = GetPromedioAlumnosAsignatura();

            foreach (var asignConPromedios in diccPromedios)
            {
                var TopPromedios = (from item in asignConPromedios.Value
                                    orderby item.promedio descending
                                   select item).Take(top);
                                
                resp.Add(asignConPromedios.Key, TopPromedios); 
            }
             return resp;
        }

        public Dictionary<String, IEnumerable<AlumnoPromedio>> GetTopPromediosAsignatura(string asignatura, int top){
            var resp = new Dictionary<String, IEnumerable<AlumnoPromedio>>();
            var diccPromedios = GetPromedioAlumnosAsignatura();
            
            foreach (var asignConPromedios in diccPromedios)
            {
                if(asignConPromedios.Key.ToLower() == asignatura.ToLower()){
                    var TopPromedios = (from item in asignConPromedios.Value
                                    orderby item.promedio descending
                                   select item).Take(top);
                    
                    resp.Add(asignConPromedios.Key, TopPromedios); 
                }
            }
            return resp;
            }
    }
}