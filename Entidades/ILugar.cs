namespace CoreEscuela.Entidades
{
    public interface ILugar
    {
        string Direccion { get; set; }

        void LimpiarLugar(){}
    }
}

//una interfaz es una definicion de la estructura que tiene que tener un objeto
//solo tiene declaracion de atributos  y de metodos, mas no los implementa
//Ademas estos atributos y metodos no tienen identificadores de acceso
//un objeto que implemente la interfaz de cumplir con la estructura de la interfaz