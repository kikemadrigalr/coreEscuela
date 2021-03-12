using System;

namespace CoreEscuela.Entidades
{
    //declarar la clase como abstract permite heredar sus caracteristicas a otras clases
    //pero no permite que la clase sea instanciada
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId { get; private set; }

        public string Nombre { get; set; }

        public ObjetoEscuelaBase()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}