using System.Collections.Generic;
using System;

namespace CoreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase
    {
        //se hace el get de tipo privado para asignarlo unicamente dentro de la clase
        // public string UniqueId { get; private set; }

        // public string Nombre { get; set; }

        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }

//inicializar id en el constructor 
        // public Curso() => UniqueId = Guid.NewGuid().ToString();
    }
}