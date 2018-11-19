using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioDominio
{
    public class Sistema
    {   /*listados*/
        List<Cliente> clientes = new List<Cliente>();
        List<Edificio> edificios = new List<Edificio>();
        //instancia
        private static Sistema instancia;

        public List<Cliente> Clientes
        {
            get { return clientes; }
        }
        public List<Edificio> Edificios
        {
            get { return edificios; }
        }

        //crea un apartamento de tipo Oficina
        private Oficina AltaApartamento(int puestosTrabajo, bool equipamiento, int piso, string numero, int metraje, string orientacion)
        {
            Oficina oficina = new Oficina(puestosTrabajo, equipamiento, piso,  numero,  metraje,  orientacion);
            
            return oficina;
        }
        //crea un apartamento de tipo CasaHabitacion
        private CasaHabitacion AltaApartamento(int dormitorio, int banios, bool garaje, int piso, string numero, int metraje, string orientacion)
        {
            CasaHabitacion casa = new CasaHabitacion(dormitorio, banios, garaje, piso, numero, metraje, orientacion);
            return casa;
        }



        //***************metodo alta Edificio con CasaHabitacion**********************
         public string AltaEdificio(string nombreEdificio, string direccionEdificio, int piso, string numero, int metraje, string orientacion, int dormitorio, int banios, bool garaje)
        {
            string mensaje;
            List<Apartamento> apartamentos = new List<Apartamento>();
            Edificio edificio = null;
            
            edificio = BuscarEdificio(nombreEdificio);

            if (edificio == null)
            {
                edificio = new Edificio(nombreEdificio, direccionEdificio, apartamentos);

                CasaHabitacion aptoCasa = AltaApartamento(dormitorio, banios, garaje, piso, numero, metraje, orientacion);

                if (!buscarApto(numero))
                {
                    edificio.Apartamentos.Add(aptoCasa);

                    if (BuscarEdificio(nombreEdificio) == null)
                    {
                        edificios.Add(edificio);
                        mensaje = "El edificio y apartamento fueron agregados";
                    }
                    else
                    {
                        mensaje = "El edificio ya existe";
                    }
                }else
                {
                    mensaje = "Ese apartamento ya existe";
                }

            }
            else
            {
                mensaje = "El edificio ya existe";
            }

            return mensaje;

        }

        //************************************** metodo alta Oficina en edificio existente **********************
        public string AgregarApartamento(string nombreEdificio, int piso, string numero, string orientacion, int metraje, int puestosTrabajo, bool equipamiento)
        {
            string mensaje;
            Edificio aModificar = BuscarEdificio(nombreEdificio);

            if (aModificar != null)
            {
                Oficina aptoOficina = AltaApartamento(puestosTrabajo, equipamiento, piso, numero, metraje, orientacion);

                if (!buscarApto(numero))
                {
                    aModificar.Apartamentos.Add(aptoOficina);
                    mensaje = "Se agrego la oficina";
                }else
                {
                    mensaje = "El apartamento ya existe";
                }

            }
            else
            {
                mensaje = "El edificio no existe";
            }

            return mensaje;
        }


        // ******************************************* metodo alta CasaHabitacion en edificio existente *************
        public string AgregarApartamento(string nombreEdificio, string direccionEdificio, int piso, string numero, int metraje, string orientacion, int dormitorio, int banios, bool garaje)
        {
            string mensaje;
            Edificio aModificar = BuscarEdificio(nombreEdificio);

            if (aModificar != null)
            {
                CasaHabitacion casa = AltaApartamento(dormitorio, banios, garaje, piso, numero, metraje, orientacion);

                if (!buscarApto(numero))
                {
                    aModificar.Apartamentos.Add(casa);
                    mensaje = "Se agrego la CasaHabitacion";
                }
                else
                {
                    mensaje = "El apartamento ya existe";
                }

            }
            else
            {
                mensaje = "El edificio no existe";
            }

            return mensaje;
        }

        //**********************metodo alta Edificio con Oficina***************************
        public string AltaEdificio(string nombreEdificio, string direccionEdificio, int piso, string numero, int metraje, string orientacion, int puestosTrabajo, bool equipamiento)
        
        {
            string mensaje;
            List<Apartamento> apartamentos = new List<Apartamento>();
            Edificio edificio = null;

            edificio = BuscarEdificio(nombreEdificio);

            if (edificio == null)
            {
                edificio = new Edificio(nombreEdificio, direccionEdificio, apartamentos);

                Oficina aptoOficina = AltaApartamento(puestosTrabajo, equipamiento, piso, numero, metraje, orientacion);

                if (!buscarApto(numero))
                {
                    edificio.Apartamentos.Add(aptoOficina);

                    if (BuscarEdificio(nombreEdificio) == null)
                    {
                        edificios.Add(edificio);
                        mensaje = "El edificio fue agregado con la oficina";
                    } else
                    {
                        mensaje = "El edificio ya existe";
                    }
                }
                else
                {
                    mensaje = "Ese apartamento ya existe";
                }

            }else
            {
                mensaje = "El edificio ya existe";
            }

            return mensaje;

        }



        //*********** metodo buscar edificio *************
        public Edificio BuscarEdificio(string nombre)
        {
            bool existe = false;
            Edificio c = null;
            int i = 0;
            while (i < edificios.Count && !existe)
            {
                if (edificios[i].Nombre.ToUpper() == nombre.ToUpper())
                {
                    existe = true;
                    c = edificios[i];
                }
                i++;
            }
            return c;
        }

        //****************** metodo buscar apto *****************
        public bool buscarApto(string numero)
        {
            bool existe = false;
            int i = 0;

            while (existe == false && i < edificios.Count)
            {
                int j = 0;

                while (existe == false && j < edificios[i].Apartamentos.Count)
                {
                    if (edificios[i].Apartamentos[j].Numero == numero)
                    {
                        existe = true;
                    }
                    j++;
                }
                i++;
            }

            return existe;
        }



        //*************metodo listado apartamentos por precio***********
        public List<Apartamento> ListadoAptoPrecio(int menor, int mayor)
        {
            List<Apartamento> rango = new List<Apartamento>();
            foreach (Edificio e in edificios)
            {
                foreach (Apartamento a in e.Apartamentos)
                {
                    if (a.PrecioBase >= menor && a.PrecioBase <= mayor)
                    {
                        rango.Add(a);
                    }
                }
            }
            return rango;
        }

        //*********************** existencia de apto segun rango de metrajes ****************************
        public bool HayApto(int menor, int mayor)
        {
            bool existe = false;
            int i = 0;

            while (existe == false && i < edificios.Count)
            {
                int j = 0;

                while (existe == false && j < edificios[i].Apartamentos.Count)
                {
                    if (edificios[i].Apartamentos[j].Metraje >= menor && edificios[i].Apartamentos[j].Metraje <= mayor)
                    {
                        existe = true;
                    }
                    j++;
                }
                i++;
            }

            return existe;
        }


        //************************ listado edificios por rango de metrajes *********************************
        public List<Edificio> ListadoEdificios(int menorMetraje, int mayorMetraje, string orientacion)
        {
            List<Edificio> listadoEdificios = new List<Edificio>();

            foreach (Edificio e in edificios)
            {
                if (menorMetraje != 0 && mayorMetraje != 0)
                    foreach (Apartamento a in e.Apartamentos)
                    {
                        if (a.Metraje >= menorMetraje && a.Metraje <= mayorMetraje && a.Orientacion == orientacion)
                        {
                            Edificio encontrado = new Edificio(e.Nombre, e.Direccion, e.Apartamentos);
                            listadoEdificios.Add(encontrado);
                        }
                    }
            }
            return listadoEdificios;
        }

        //*********** metodo alta apartamento ******************
        public string AltaApartamento(int piso, string numero, int metraje, string orientacion, string edificio, bool esOficina, int dormitorio, int banios, bool garaje, bool equipamiento, int puestosTrabajo)
        {
            string mensaje = "";
            Edificio e = BuscarEdificio(edificio);
            if (e != null)
            {
                if (esOficina)
                {
                    e.Apartamentos.Add(new Oficina(puestosTrabajo, equipamiento, piso, numero, metraje, orientacion));
                }
                else
                {
                    e.Apartamentos.Add(new CasaHabitacion(dormitorio, banios, garaje, piso, numero, metraje, orientacion));
                }
            }else { mensaje = "El edificio no existe."; }
            return mensaje;
        }

        //***Metodo muestra de aptos******
        public List<Apartamento> CargaAptos()
        {
            List<Apartamento> aptos = new List<Apartamento>();
            foreach (Edificio e in edificios)
            {
                foreach (Apartamento a in e.Apartamentos)
                {
                    aptos.Add(a);
                }
            }
            return aptos;
        }

        //************* DATOS DE PRUEBA ******************
        public void CargarDatos()
        {
            //EDIFICIOS CON OFICINAS
            //AltaApartamento(int piso, string numero, int metraje, string orientacion, string edificio, bool esOficina, int dormitorio, int banios, bool garaje, bool equipamiento, int puestosTrabajo)
            this.AltaEdificio("Nostrum", "AvUruguay", 2, "2SO", 70, "SO", 2,true);
            this.AltaEdificio("Altos", "CiudadVieja", 1, "1N", 20, "N", 3, true);
            this.AltaEdificio("BPS", "ArenalGrande", 3, "3SO", 200, "SO", 5, true);
            //EDIFICIOS CON CASAS
            //AltaEdificio(string nombreEdificio, string direccionEdificio, int piso, string numero, int metraje, string orientacion, int dormitorio, int banios, bool garaje);
            this.AltaEdificio("HBC", "AvRivera", 4, "4SO", 125, "SO", 2, 2, true);
            this.AltaEdificio("TrumpTower", "PdeE", 4, "2S", 162, "S", 4, 1, true);
            this.AltaEdificio("TorreProfesionales", "Yaguaron", 5, "5E", 120, "E", 4, 4, true);

            //OFICINAS
            //this.AltaApartamento(int puestosTrabajo, bool equipamiento, int piso, string numero, int metraje, string orientacion);
            this.AltaApartamento(6, true, 3, "3E", 90, "E");
            this.AltaApartamento(3, true, 4, "4O", 55, "O");
            this.AltaApartamento(1, false, 1, "1S", 30, "S");
            //APARTAMENTOS
            //AltaApartamento(int dormitorio, int banios, bool garaje, int piso, string numero, int metraje, string orientacion);
            this.AltaApartamento(3, 1, false, 1, "1SE", 90, "SE");
            this.AltaApartamento(1, 1, false, 4, "4N", 30, "N");
            this.AltaApartamento(5, 2, true, 10, "10S", 150, "S");
            
        }

        //***************** singleton ****************
        public static Sistema Instancia 
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sistema();
                }
                return instancia;
            }
        }
        private Sistema() { CargarDatos(); }
    }
}
