using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObligatorioDominio;

namespace Obligatorio2.Controllers
{
    public class ListadoClientesController : Controller
    {
        // GET: ListadoClientes
        public ActionResult Index()
        {
            List<Cliente> c = Sistema.Instancia.ClientesOrdenado();
            ViewBag.listado = c; 
            return View();
        }
        [HttpPost]
        public ActionResult Index(DateTime inicio, DateTime final)
        {
            List<Cliente> c = Sistema.Instancia.FiltrarClientes(inicio, final);
            ViewBag.listado = c;
            return View();
        }
    }
}
