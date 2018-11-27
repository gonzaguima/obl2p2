using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioDominio
{
    public class Sistema
    {   /*listados*/
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        public List<Edificio> Edificios { get; set; } = new List<Edificio>();
        //instancia
        private static Sistema instancia;

        //Metodos para Usuario.

        //public bool AltaUsuario(string user, string pass)
        //{
        //    bool alta = false;
        //    if (user != "" && pass != "")
        //    {
        //        Usuario u = BuscarUsuario(user);
        //        if (u == null)
        //        {
        //            u = new Usuario(user, pass);
        //            usuarios.Add(u);
        //            alta = true;
        //        }
        //    }
        //    return alta;
        //}

        public object BuscarUsuario(string user, string pass)
        {
            object u = null;
            int x = 0;
                while (x < Vendedores.Count && u == null) //Si no lo encuentro en cliente, lo busco en vendedor
                {
                    if (Vendedores[x].User == user)
                    {
                        if (Vendedores[x].Pass == pass)
                        {
                            u = Clientes[x];
                        }
                    }
                    x++;
                }
            return u;
        }

        public Vendedor BuscarUsuarioV(object user)
        {
            Vendedor v = null;

            if (user is Vendedor)
            {
                int i = 0;
                while (i < Vendedores.Count && v == null)
                {
                    if (Vendedores[i].User == "vend1" || Vendedores[i].User == "vend2")
                    {
                        v = Vendedores[i];
                    }
                    i++;
                }
            }
            return v;
        }

        //VENTAS
        public bool AltaVendedor(string user, string pass)
        {
            bool alta = false;
            if (user != "" && pass != "") //Verifico que no sean vacios
            {
                if (Vendedores.Count != 0)
                {
                    if (BuscarVendedor(user) == null) //Busco si ya existe el Cliente, comparando por user
                    {
                        Vendedores.Add(new Vendedor(user, pass));
                        alta = true;
                    }
                }
                else
                {
                    Vendedores.Add(new Vendedor(user, pass));
                    alta = true;
                }
            }
            return alta;
        }

        private Vendedor BuscarVendedor(string user) 
        {
            Vendedor v = null;
            int i = 0;
            while (i < Vendedores.Count && v == null)
            {
                if (Vendedores[i].User == user)
                {
                    v = Vendedores[i];
                }
                i++;
            }
            return v;
        }

        //ABM Clientes
        public bool AltaCliente(string nombre, string apellido, string documento, string direccion, int telefono, string user, string pass)
        {
            bool alta = false;
            if (nombre != "" && apellido != "" && documento != "" && direccion != "" && pass != "" && user != "") //Verifico que ninguno sea vacio
            {
                Cliente c = BuscarCliente(documento); //Busco si ya existe el Cliente, comparando por documento
                if (c == null) //Verifico que no exista
                { //Si no existe, creo el nuevo Cliente
                    c = new Cliente(nombre, apellido, documento, direccion, telefono, user, pass);
                    Clientes.Add(c);
                    alta = true;
                }
            }
            return alta;
        }
        public Cliente BuscarCliente(string documento)
        {
            Cliente c = null;
            int i = 0;
                while (i < Clientes.Count && c == null) 
                {
                    if (Clientes[i].Documento == documento)
                    {
                        c = Clientes[i];
                    }
                    i++;
                } 
            return c;
        }

        public bool BajaCliente(string documento)
        {
            bool baja = false;
            Cliente c = BuscarCliente(documento);
            if (c != null)
            {
                if (c.Compras.Count == 0) //Si tiene compras no lo elimina
                {
                    Clientes.Remove(c);
                    baja = true;
                }
            }
            return baja;
        }

        public bool ModCliente(string nombre, string apellido, string documento, string direccion, int telefono, string user, string pass)
        {
            bool mod = false;
            if (nombre != "" && apellido != "" && documento != "" && direccion != "" && pass != "" && user != "")
            {
                Cliente c = BuscarCliente(documento);
                if (c != null)
                {
                    c.Nombre = nombre;
                    c.Apellido = apellido;
                    //c.Documento = documento; El documento no se cambia.
                    c.Direccion = direccion;
                    c.Telefono = telefono;
                    c.User = user;
                    c.Pass = pass;
                    mod = true;
                } 
            }
            return mod;
        }
        
        public List<Cliente> FiltrarClientes(DateTime fechai, DateTime fechaf)
        {
            List<Cliente> filtrada = new List<Cliente>();
            //Filtrar por fecha
            foreach (var i in Clientes)
            {
                if (i.Filtrado(fechai, fechaf))
                {
                    filtrada.Add(i);
                }
            }
            
            return filtrada;
        }

       
        #region obl1
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
                        Edificios.Add(edificio);
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
                        Edificios.Add(edificio);
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
            while (i < Edificios.Count && !existe)
            {
                if (Edificios[i].Nombre.ToUpper() == nombre.ToUpper())
                {
                    existe = true;
                    c = Edificios[i];
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

            while (existe == false && i < Edificios.Count)
            {
                int j = 0;

                while (existe == false && j < Edificios[i].Apartamentos.Count)
                {
                    if (Edificios[i].Apartamentos[j].Numero == numero)
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
            foreach (Edificio e in Edificios)
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

            while (existe == false && i < Edificios.Count)
            {
                int j = 0;

                while (existe == false && j < Edificios[i].Apartamentos.Count)
                {
                    if (Edificios[i].Apartamentos[j].Metraje >= menor && Edificios[i].Apartamentos[j].Metraje <= mayor)
                    {
                        existe = true;
                    }
                    j++;
                }
                i++;
            }

            return existe;
        }


        //************************ listado Edificios por rango de metrajes *********************************
        public List<Edificio> ListadoEdificios(int menorMetraje, int mayorMetraje, string orientacion)
        {
            List<Edificio> listadoEdificios = new List<Edificio>();

            foreach (Edificio e in Edificios)
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
            foreach (Edificio e in Edificios)
            {
                foreach (Apartamento a in e.Apartamentos)
                {
                    aptos.Add(a);
                }
            }
            return aptos;
        }

        public List<Apartamento> BuscarApartamentos(string nombre)
        {
            List<Apartamento> aptos = new List<Apartamento>();
            Edificio e = BuscarEdificio(nombre);
            if (e != null)
            {
                aptos = e.Apartamentos;
            }
            return aptos;
        }


        #endregion
        #region datos
        //************* DATOS DE PRUEBA ******************
        public void CargarDatos()
        {
            //Edificios CON OFICINAS
            //AltaApartamento(int piso, string numero, int metraje, string orientacion, string edificio, bool esOficina, int dormitorio, int banios, bool garaje, bool equipamiento, int puestosTrabajo)
            this.AltaEdificio("Nostrum", "AvUruguay", 2, "2SO", 70, "SO", 2,true);
            this.AltaEdificio("Altos", "CiudadVieja", 1, "1N", 20, "N", 3, true);
            this.AltaEdificio("BPS", "ArenalGrande", 3, "3SO", 200, "SO", 5, true);
            //Edificios CON CASAS
            //AltaEdificio(string nombreEdificio, string direccionEdificio, int piso, string numero, int metraje, string orientacion, int dormitorio, int banios, bool garaje);
            this.AltaEdificio("HBC", "AvRivera", 4, "4SO", 125, "SO", 2, 2, true);
            this.AltaEdificio("TrumpTower", "PdeE", 4, "2S", 162, "S", 4, 1, true);
            this.AltaEdificio("TorreProfesionales", "Yaguaron", 5, "5E", 120, "E", 4, 4, true);
           
            //CLIENTE
            this.AltaCliente("Pablo", "Ingold", "48684676", "Guazunambi", 094992993, "pingold", "123456");
            this.AltaCliente("Juan", "Lopetegui", "34561871", "Silvestre", 092158632, "jlope", "147852");
            this.AltaCliente("Alberto", "Villanueva", "41258643", "CerroLargo", 098124856, "avilla", "520147");

            //VENDEDOR
            this.AltaVendedor("vend1", "vend1111");
            this.AltaVendedor("vend2", "vend2222");

            agregarApto("Nostrum");
            agregarApto("Altos");
            agregarApto("BPS");
            agregarApto("HBC");
            agregarApto("TrumpTower");
            agregarApto("TorreProfesionales");
        }
        
        public void agregarApto(string nombre)
        {
            Edificio e = BuscarEdificio(nombre);
            //OFICINAS
            //this.AltaApartamento(int puestosTrabajo, bool equipamiento, int piso, string numero, int metraje, string orientacion);
            e.Apartamentos.Add(AltaApartamento(6, true, 3, "3E", 90, "E"));
            e.Apartamentos.Add(AltaApartamento(3, true, 4, "4O", 55, "O"));
            e.Apartamentos.Add(AltaApartamento(1, false, 1, "1S", 30, "S"));
            //APARTAMENTOS
            //AltaApartamento(int dormitorio, int banios, bool garaje, int piso, string numero, int metraje, string orientacion);
            e.Apartamentos.Add(AltaApartamento(3, 1, false, 1, "1SE", 90, "SE"));
            e.Apartamentos.Add(AltaApartamento(1, 1, false, 4, "4N", 30, "N"));
            e.Apartamentos.Add(AltaApartamento(5, 2, true, 10, "10S", 150, "S"));
        }


        #endregion
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
