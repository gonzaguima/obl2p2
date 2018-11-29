using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioDominio
{
     public class Compra
    {
        public DateTime fecha { get; }
        public Vendedor vendedor { get; }
        public int precio { get; }
        public Apartamento apartamento { get; }
        public Cliente cliente { get; }

        public Compra(DateTime fecha, Vendedor vendedor, int precio, Apartamento apartamento, Cliente cliente)
        {
            this.fecha = fecha.Date;
            this.vendedor = vendedor;
            this.precio = precio;
            this.apartamento = apartamento;
            this.cliente = cliente;
        }
        public Compra() { }
        public override string ToString()
        {
            float com = apartamento.Edif.Comision;
            float por = com / 100;
            return this.apartamento.Datos() + " Cliente: " + this.cliente.ToString() + " Comision: " + (precio * por);
        }
        public string idCompra()
        {
            return apartamento.Piso + apartamento.Numero + apartamento.Orientacion + apartamento.Edif;
        }

        public string mostrarCompra()
        {
            return this.apartamento.Datos();
        }
        public bool ExisteVend(Vendedor v)
        {
            bool esta = false;
            if (v == vendedor)
            {
                esta = true;
            }
            return esta;
        }
    }
}
