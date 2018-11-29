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

        //Metodo para Login.
        public Vendedor BuscarUsuario(string user, string pass) //Validar Vendedor que se esta logueando
        {
            Vendedor u = null;
            int x = 0;
                while (x < Vendedores.Count && u == null) //lo busco en vendedor
                {
                    if (Vendedores[x].User == user)
                    {
                        if (Vendedores[x].Pass == pass) //Verifica si la password es correcta y devuelve el objeto vendedor 
                        {
                            u = Vendedores[x];
                        }
                    }
                    x++;
                }
            return u;
        }


        //VENTAS
        public bool AltaVendedor(string user, string pass)
        {
            bool alta = false;
            if (user != "" && pass != "") //Verifico que no sean vacios
            {
                if (BuscarVendedor(user) == null) //Busco si ya existe el Cliente, comparando por user
                {
                    Vendedores.Add(new Vendedor(user, pass));
                    alta = true;
                }
            }
            return alta;
        }

        public Vendedor BuscarVendedor(string user) 
        {
            Vendedor v = null;
            int i = 0;
            while (i < Vendedores.Count && v == null) //Recorro la lista, al encontrarlo salgo del while
            {
                if (Vendedores[i].User == user)
                {
                    v = Vendedores[i];
                }
                i++;
            }
            return v;
        }

        public List<Compra> ListaVentas(string user)
        {
            Vendedor v = BuscarVendedor(user); //Obtengo el objeto del vendedor logueado
            List<Compra> ventas = new List<Compra>(); //Inicio la lista para agregarle las Compras efectuadas por este vendedor
            foreach (var i in Clientes) //Recorro los clientes, porque son quienes contienen las compras
            {
                List<Compra> parcial = i.ExisteVend(v); //Agrego a una lista 
                if (parcial != null)
                {
                    foreach (var j in parcial) 
                    {
                        ventas.Add(j);
                    }
                }
            }
            return ventas;
        }

        public bool AltaVenta(string vendedor, string apartamento, string edificio, string cliente)
        {
            bool alta = false;
            Vendedor v = BuscarVendedor(vendedor);
            Edificio e = BuscarEdificio(edificio);
            Apartamento apto = e.BuscarApto(apartamento);

            if(BuscarCliente(cliente).AltaCompra(v, e, apto))
            {
                alta = true;
            }
            return alta;
        }

        //ABM Clientes
        public bool AltaCliente(string nombre, string apellido, string documento, string direccion, int telefono)
        {
            bool alta = false;
            if (nombre != "" && apellido != "" && documento != "" && direccion != "") //Verifico que ninguno sea vacio
            {
                Cliente c = BuscarCliente(documento); //Busco si ya existe el Cliente, comparando por documento
                if (c == null) //Verifico que no exista
                { //Si no existe, creo el nuevo Cliente
                    c = new Cliente(nombre, apellido, documento, direccion, telefono);
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
                while (i < Clientes.Count && c == null) //Recorro la lista, al encontrarlo salgo del while
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

        public bool ModCliente(string nombre, string apellido, string documento, string direccion, int telefono)
        {
            bool mod = false;
            if (nombre != "" && apellido != "" && documento != "" && direccion != "")
            {
                Cliente c = BuscarCliente(documento); //Tomo el documento para buscarlo.
                if (c != null)
                {
                    c.Nombre = nombre;
                    c.Apellido = apellido;
                    //El documento no se cambia.
                    c.Direccion = direccion;
                    c.Telefono = telefono;
                    mod = true;
                } 
            }
            return mod;
        }
        
        public List<Cliente> FiltrarClientes(DateTime fechai, DateTime fechaf, string vend)
        {
            List<Cliente> filtrada = new List<Cliente>();
            Vendedor v = BuscarVendedor(vend);
            //Filtrar por fecha
            foreach (var i in Clientes)
            {
                if (i.Filtrado(fechai, fechaf, v)) //Si el cliente tiene alguna compra entre
                {                               //estas 2 fechas, devuelve un true.
                    filtrada.Add(i);
                }
            }
            filtrada.Sort(); //Ordenar lista por el valor por defecto 
            return filtrada;
        }

        //Metodo para devolver Clientes ordenados
        public List<Cliente> ClientesOrdenado()
        {
            List<Cliente> c = Clientes;
            c.Sort();
            return c;
        }

        #region obl1
        //crea un apartamento de tipo Oficina
        private Oficina AltaApartamento(int puestosTrabajo, bool equipamiento, int piso, string numero, int metraje, string orientacion, Edificio e)
        {
            Oficina oficina = new Oficina(puestosTrabajo, equipamiento, piso, numero, metraje, orientacion, e);
            return oficina;
        }
        //crea un apartamento de tipo CasaHabitacion
        private CasaHabitacion AltaApartamento(int dormitorio, int banios, bool garaje, int piso, string numero, int metraje, string orientacion, Edificio e)
        {
            CasaHabitacion casa = new CasaHabitacion(dormitorio, banios, garaje, piso, numero, metraje, orientacion, e);
            return casa;
        }

        //***************metodo alta Edificio con CasaHabitacion**********************
        public string AltaEdificio(string nombreEdificio, string direccionEdificio, int comision, int piso, string numero, int metraje, string orientacion, int dormitorio, int banios, bool garaje)
        {
            string mensaje;
            List<Apartamento> apartamentos = new List<Apartamento>();
            Edificio edificio = null;
            
            edificio = BuscarEdificio(nombreEdificio);

            if (edificio == null)
            {
                edificio = new Edificio(nombreEdificio, direccionEdificio, apartamentos, comision);

                CasaHabitacion aptoCasa = AltaApartamento(dormitorio, banios, garaje, piso, numero, metraje, orientacion, edificio);

                if (buscarApto(numero) == null)
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
                Oficina aptoOficina = AltaApartamento(puestosTrabajo, equipamiento, piso, numero, metraje, orientacion, aModificar);

                if (buscarApto(numero) == null)
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
                CasaHabitacion casa = AltaApartamento(dormitorio, banios, garaje, piso, numero, metraje, orientacion, aModificar);

                if (buscarApto(numero) == null)
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
        public string AltaEdificio(string nombreEdificio, string direccionEdificio, int comision, int piso, string numero, int metraje, string orientacion, int puestosTrabajo, bool equipamiento)
        
        {
            string mensaje;
            List<Apartamento> apartamentos = new List<Apartamento>();
            Edificio edificio = null;

            edificio = BuscarEdificio(nombreEdificio);

            if (edificio == null)
            {
                edificio = new Edificio(nombreEdificio, direccionEdificio, apartamentos, comision);

                Oficina aptoOficina = AltaApartamento(puestosTrabajo, equipamiento, piso, numero, metraje, orientacion, edificio);

                if (buscarApto(numero) == null)
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


        public Apartamento buscarApto(string numero)
        {
            bool existe = false;
            int i = 0;
            Apartamento a = null;
            while (existe == false && i < Edificios.Count)
            {
                int j = 0;

                while (existe == false && j < Edificios[i].Apartamentos.Count)
                {
                    if (Edificios[i].Apartamentos[j].Numero == numero)
                    {
                        a = Edificios[i].Apartamentos[j];
                        existe = true;
                    }
                    j++;
                }
                i++;
            }

            return a;
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
                            Edificio encontrado = e;
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
                    e.Apartamentos.Add(new Oficina(puestosTrabajo, equipamiento, piso, numero, metraje, orientacion, e));
                }
                else
                {
                    e.Apartamentos.Add(new CasaHabitacion(dormitorio, banios, garaje, piso, numero, metraje, orientacion, e));
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
                aptos = e.AgregarAptos();
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
            this.AltaEdificio("Nostrum", "AvUruguay", 12, 2, "2SO", 70, "SO", 2,true);
            this.AltaEdificio("Altos", "CiudadVieja", 15, 1, "1N", 20, "N", 3, true);
            this.AltaEdificio("BPS", "ArenalGrande", 17, 3, "3SO", 200, "SO", 5, true);
            //Edificios CON CASAS
            //AltaEdificio(string nombreEdificio, string direccionEdificio, int piso, string numero, int metraje, string orientacion, int dormitorio, int banios, bool garaje);
            this.AltaEdificio("HBC", "AvRivera", 16, 4, "4SO", 125, "SO", 2, 2, true);
            this.AltaEdificio("TrumpTower", "PdeE", 23, 4, "2S", 162, "S", 4, 1, true);
            this.AltaEdificio("TorreProfesionales", "Yaguaron", 7, 5, "5E", 120, "E", 4, 4, true);
           
            //CLIENTE
            this.AltaCliente("Pablo", "Ingold", "48684676", "Guazunambi", 094992993);
            this.AltaCliente("Juan", "Lopetegui", "34561871", "Silvestre", 092158632);
            this.AltaCliente("Alberto", "Villanueva", "41258643", "CerroLargo", 098124856);

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
        
        private void agregarApto(string nombre)
        {
            Edificio e = BuscarEdificio(nombre);
            //OFICINAS
            //this.AltaApartamento(int puestosTrabajo, bool equipamiento, int piso, string numero, int metraje, string orientacion);
            e.Apartamentos.Add(AltaApartamento(6, true, 3, "3E", 90, "E", e));
            e.Apartamentos.Add(AltaApartamento(3, true, 4, "4O", 55, "O", e));
            e.Apartamentos.Add(AltaApartamento(1, false, 1, "1S", 30, "S", e));
            //APARTAMENTOS
            //AltaApartamento(int dormitorio, int banios, bool garaje, int piso, string numero, int metraje, string orientacion);
            e.Apartamentos.Add(AltaApartamento(3, 1, false, 1, "1SE", 90, "SE", e));
            e.Apartamentos.Add(AltaApartamento(1, 1, false, 4, "4N", 30, "N", e));
            e.Apartamentos.Add(AltaApartamento(5, 2, true, 10, "10S", 150, "S", e));
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
