using System;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        //se hace el get de tipo privado para asignarlo unicamente dentro de la clase
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }

//inicializar id en el constructor 
        public Curso() => UniqueId = Guid.NewGuid().ToString();
    }
}