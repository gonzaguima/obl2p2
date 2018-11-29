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
        public double precio { get; }
        public Apartamento apartamento { get; }
        public Cliente cliente { get; }

        public Compra(DateTime fecha, Vendedor vendedor, Apartamento apartamento, Cliente cliente)
        {
            this.fecha = fecha.Date;
            this.vendedor = vendedor;
            //this.precio = precio;
            this.precio = apartamento.Precio();
            this.apartamento = apartamento;
            this.cliente = cliente;
        }
        public Compra() { }
        public override string ToString()
        {
            double com = apartamento.Edif.Comision;
            double por = com / 100;
            double comisionFinal = por * apartamento.Precio();
            return " Cliente: " + this.cliente.ToString() + " Comision: " + (comisionFinal) + " Precio: " + apartamento.Precio();
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
