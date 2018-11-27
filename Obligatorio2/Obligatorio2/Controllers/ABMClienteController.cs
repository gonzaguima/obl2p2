using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObligatorioDominio;

namespace Obligatorio2.Controllers
{
    public class ABMClienteController : Controller
    {
        // GET: ABMCliente
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Alta() { return View(); }
        public ActionResult Baja() { return View(); }
        public ActionResult Mod() { return View(); }
        [HttpPost]
        public ActionResult Alta(string nombre, string apellido, string documento, string direccion, int telefono, string user, string pass)
        {
            //Recibe los datos del formulario 
            if (nombre != "" && apellido != "" && documento != "" && direccion != "" && telefono != 0 && pass != "" && user != "")
            { //Verifica que no sean vacios
                if (Sistema.Instancia.AltaCliente(nombre, apellido, documento, direccion, telefono, user, pass))
                {
                    ViewBag.resultado = "Alta exitosa";
                }
                else { ViewBag.resultado = "Alta fallida"; }
            }
            else { ViewBag.resultado = "Los campos son obligatorios"; }
            return View("Alta");
        }
        [HttpPost]
        public ActionResult Baja(string borrador)
        {
            if (Sistema.Instancia.BajaCliente(borrador))
            {
                ViewBag.resultado = "Baja realizada con exito!";
            } else { ViewBag.resultado = "Imposible borrar este cliente"; }
            return View("Baja");
        }

        public ActionResult CargarDatos(string cliente)
        {
            Cliente c = Sistema.Instancia.BuscarCliente(cliente);
            @ViewBag.nombre = c.Nombre;
            @ViewBag.apellido = c.Apellido;
            @ViewBag.documento = c.Documento;
            @ViewBag.direccion = c.Direccion;
            @ViewBag.telefono = c.Telefono;
            @ViewBag.user = c.User;
            @ViewBag.pass = c.Pass;
            return View("Mod");
        }
        [HttpPost]
        public ActionResult Mod(string nombre, string apellido, string documento, string direccion, int telefono, string user, string pass)
        {
            if (Sistema.Instancia.ModCliente(nombre, apellido, documento, direccion, telefono, user, pass))
            {
                ViewBag.resultado = "Modificacion exitosa";
            }
            return View();
        }
    }
}
