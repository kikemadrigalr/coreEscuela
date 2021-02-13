namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;
        //encapsulamiento de la propiedad nombre
        public string Nombre{
          get{ return "Copia: " + nombre; }
          set{ nombre = value.ToUpper(); }
        }

        //otra forma de crear y encapsular las propiedades y hacer setter y getter
        public int AnioCreacion{ get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        // la propiedad TipoEscuela sera del TiposEscuelas
        //el cual es un objeto Enumeraable creado a nivel de las entidades
        public TiposEscuela TipoEscuela { get; set; }

        //constructor
        // public Escuela(string nombre, int anio){
        //   this.nombre = nombre;
        //   AnioCreacion = anio;
        // }

        //otra forma de escribir el Constructor utilizando igualacion por tuplas
        public Escuela(string nombre, int anio) => (Nombre, AnioCreacion) = (nombre, anio);

        //sobreescribiendo el metodo ToSting para la clase Escuela
        public override string ToString()
        {
          return $"Nombre: {Nombre}, Tipo: {TipoEscuela}, \nPais: {Pais}, Ciudad: {Ciudad}";
        }

    }
}