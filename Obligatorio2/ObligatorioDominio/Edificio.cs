using System;
using System.Collections.Generic;

namespace ObligatorioDominio
{
    public class Edificio
    {
        private string nombre;
        private string direccion;
        private List<Apartamento> apartamentos;
        
        public Edificio(string nombre, string direccion, List<Apartamento> apartamentos)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.apartamentos = apartamentos;
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

    }
}
