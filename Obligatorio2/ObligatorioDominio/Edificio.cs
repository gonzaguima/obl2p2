using System;
using System.Collections.Generic;

namespace ObligatorioDominio
{
    public class Edificio
    {
        private string nombre;
        private string direccion;
        private List<Apartamento> apartamentos;
        public int Comision { get; set; }

        public Edificio(string nombre, string direccion, List<Apartamento> apartamentos, int comision)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.apartamentos = apartamentos;
            this.Comision = comision;
        }


        public string Nombre
        {
            get { return nombre; }
        }
        public string Direccion
        {
            get { return direccion; }
        }
        public List<Apartamento> Apartamentos
        {
            get { return apartamentos; }
            set { apartamentos = value; }
        }

        public override string ToString()
        {
            return this.Nombre;
        }

        internal Apartamento BuscarApto(string apartamento)
        {
            Apartamento apto = null;
            int i = 0;
            while (i < Apartamentos.Count && apto == null)
            {
                if (Apartamentos[i].ToString() == apartamento)
                {
                    apto = Apartamentos[i];
                }
                i++;
            }
            return apto;
        }

        internal List<Apartamento> AgregarAptos()
        {
            List<Apartamento> n = new List<Apartamento>();
            foreach(var i in Apartamentos)
            {
                if (!i.Vendido)
                {
                    n.Add(i);
                }
            }
            return n;
        }
    }
}
