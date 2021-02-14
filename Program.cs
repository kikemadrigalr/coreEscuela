﻿using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi School", 2012);
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Bogotá";
            escuela.TipoEscuela = TiposEscuela.Primaria;
            Console.WriteLine(escuela);

            var escuela2 = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, ciudad:"Bogotá");
            Console.WriteLine(escuela2);

            var curso1 = new Curso(){
                Nombre = "101"
            };

            var curso2 = new Curso(){
                Nombre = "201"
            };

            var curso3 = new Curso(){
                Nombre = "301"
            };

            Console.WriteLine("=========CURSOS=======");
            Console.WriteLine($"Curso: {curso1.Nombre} - {curso1.UniqueId}");
            Console.WriteLine($"Curso: {curso2.Nombre} - {curso2.UniqueId}");
            Console.WriteLine($"Curso: {curso3.Nombre} - {curso3.UniqueId}");
        }
    }
}
