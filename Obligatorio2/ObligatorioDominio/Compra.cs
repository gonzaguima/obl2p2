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
        private Vendedor vendedor;
        private int precio;
        private Apartamento apartamento;
        private Cliente cliente;

        public Compra(DateTime fecha, Vendedor vendedor, int precio, Apartamento apartamento, Cliente cliente)
        {
            this.fecha = fecha;
            this.vendedor = vendedor;
            this.precio = precio;
            this.apartamento = apartamento;
            this.cliente = cliente;
        }
        public override string ToString()
        {
            return this.fecha.ToString() + " " + this.apartamento.ToString()  ;
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
