using System.Collections.Generic;

namespace ObligatorioDominio
{
    public class Cliente : Usuario
    {
        private string nombre;
        private string apellido;
        private string documento;
        private string direccion;
        private int telefono;
        List<Compra> compras = new List<Compra>();
        public string Nombre
        {
            get { return nombre; }
            //set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            //set { apellido = value; }
        }
        public string Documento
        {
            get { return documento; }
            //set { documento = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            //set { direccion = value; }
        }
        public int Telefono
        {
            get { return telefono; }
            //set { telefono = value; }
        }
        internal void ModificarDatos(string nombre, string apellido, string documento, string direccion, int telefono)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }
}
