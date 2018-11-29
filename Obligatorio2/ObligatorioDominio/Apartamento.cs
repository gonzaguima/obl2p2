namespace ObligatorioDominio
{
    public abstract class Apartamento
    {
        private int piso;
        private string numero;
        private int metraje;
        private int precioBase;
        private string orientacion;
        public bool Vendido { get; set; }

        public Apartamento(int piso, string numero, int metraje, string orientacion)
        {
            this.piso = piso;
            this.numero = numero;
            this.metraje = metraje;
            this.orientacion = orientacion;
            this.Vendido = false;
        }

        public int Piso
        {
            get { return piso; }
            set { piso = value; }
        }

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public int Metraje
        {
            get { return metraje; }
            set { metraje = value; }
        }

        public int PrecioBase
        {
            get { return precioBase; }
            set { precioBase = 150000; }
        }

        public string Orientacion
        {
            get { return orientacion; }
            set { orientacion = value; }
        }
        //metodo para polimorfismo
        public virtual string Datos()
        {
            return "Piso: " + this.piso + " Metraje: " + this.metraje + " Orientación: " + this.orientacion;
        }

        public override string ToString()
        {
            return this.Numero;
        }

 
    }
}
