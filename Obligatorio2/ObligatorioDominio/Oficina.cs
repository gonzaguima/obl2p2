using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioDominio
{
    public class Oficina:Apartamento
    {
        private int puestosTrabajo;
        private bool equipamiento;
        private int precioFinalOficina = 2000;

        public Oficina(int puestosTrabajo, bool equipamiento, int piso, string numero, int metraje, string orientacion, Edificio e) : base(piso, numero, metraje, orientacion, e)
        {
            this.puestosTrabajo = puestosTrabajo;
            this.equipamiento = equipamiento;
        }
  
        public int PuestosTrabajo
        {
            get { return puestosTrabajo; }
            set { puestosTrabajo = value; }
        }

        public bool Equipamiento
        {
            get { return equipamiento; }
            set { equipamiento = value; }
        }

        public override double Precio()
        {
            double valor = (precioFinalOficina * Metraje) + (puestosTrabajo * 400);
           if (equipamiento)
            {
                valor = valor *  1.1;
            }
            return valor;
        }
        
        public int PrecioFinalOficina
        {
            get {return precioFinalOficina; }
            set {precioFinalOficina = value; }
        }
        //retorna el numero del apartamento que lo identifica
        //public override string Datos()
        //{
        //    return this.Numero;
        //}
    }
}
