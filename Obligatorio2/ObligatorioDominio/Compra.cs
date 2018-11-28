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
        public int comision { get; }
        public Apartamento apartamento { get; }
        public Cliente cliente { get; }

        public Compra(DateTime fecha, Vendedor vendedor, int precio, int comision, Apartamento apartamento, Cliente cliente)
        {
            this.fecha = fecha;
            this.vendedor = vendedor;
            this.precio = precio;
            this.comision = comision;
            this.apartamento = apartamento;
            this.cliente = cliente;
        }
        public Compra() { }
        public override string ToString()
        {
            return this.cliente.ToString() + " | " + this.apartamento.ToString() + " | " + this.precio;
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
