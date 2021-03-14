using System.Collections.Generic;
using System;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase, ILugar
    {
        //se hace el get de tipo privado para asignarlo unicamente dentro de la clase
        // public string UniqueId { get; private set; }

        // public string Nombre { get; set; }

        public TiposJornada Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Salón");
            Console.WriteLine($"Curso: {Nombre}, Está Limpio");
        }

    //inicializar id en el constructor 
    // public Curso() => UniqueId = Guid.NewGuid().ToString();
  }
}