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
        public IEnumerable<Escuela> GetListaEvaluaciones(){
            IEnumerable<Escuela> listaRetorno;

            var respta = _diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista);

            if(respta == true){
                listaRetorno = lista.Cast<Escuela>();
            }else{
                listaRetorno = null;
                //Por ejemplo escribir log de auditoria en caso de no obtener datos
            }

            return listaRetorno;
        }
    }
}