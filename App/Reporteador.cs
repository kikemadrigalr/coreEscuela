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
    }
}