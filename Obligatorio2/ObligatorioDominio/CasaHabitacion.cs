using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioDominio
{
    public class CasaHabitacion:Apartamento
    {
        private int dormitorios;
        private int banios;
        private bool garaje;
        private int precioFinalCasa = 200000;

        public CasaHabitacion(int dormitorios, int banios, bool garaje, int piso, string numero, int metraje, string orientacion, Edificio e):base(piso, numero, metraje, orientacion, e)
        {
            this.dormitorios = dormitorios;
            this.banios = banios;
            this.garaje = garaje;
        }
                
        public int Dormitorios
        {
            get { return dormitorios; }
            set { dormitorios = value; }
        }
        public int Banios
        {
            get { return banios; }
            set { banios = value; }
        }
        public bool Garaje
        {
            get { return garaje; }
            set { garaje = value; }
        }

        public int PrecioFinalCasa
        {
            get { return precioFinalCasa; }
            set { precioFinalCasa = value; }
        }
        //retorna el numero de apartamento que lo identifica
        public override string Datos()
        {
            return this.Numero;
        }

    }
}
