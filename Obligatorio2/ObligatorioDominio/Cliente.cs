using System;
using System.Collections;
using System.Collections.Generic;

namespace ObligatorioDominio
{
    public class Cliente : Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public List<Compra> Compras { get; set; } = new List<Compra>();
        public Cliente(string nombre, string apellido, string documento, string direccion, int telefono, string user, string pass):base(user, pass)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Documento = documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }
        //public Cliente() { }
        public override string ToString()
        {
            return this.Nombre + " " + this.Apellido;
        }

        internal bool Filtrado(DateTime fechai, DateTime fechaf)
        {
            bool val = false;
            foreach (var i in this.Compras)
            {
                if (i.fecha >= fechai && i.fecha <= fechaf)
                {
                    val = true;
                }
            }
            return val;
        }
        public int CompareTo(Cliente c)
        {
            return this.Nombre.CompareTo(c.Nombre);
        }
    }
}
