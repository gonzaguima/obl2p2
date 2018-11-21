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
            if (Sistema.Instancia.AltaCliente(nombre, apellido, documento, direccion, telefono, user, pass))
            {
                ViewBag.resultado("Alta exitosa");
            }
            else { ViewBag.resultado("Alta fallida"); }
            return View();
        }
        [HttpPost]
        public ActionResult Baja() { return View(); }
        [HttpPost]
        public ActionResult Mod() { return View(); }
    }
}
