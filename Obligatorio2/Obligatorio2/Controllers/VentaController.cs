using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObligatorioDominio;

namespace Obligatorio2.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarApartamentos(string edificio)
        {
            ViewBag.Apartamento = Sistema.Instancia.BuscarApartamentos(edificio);
            ViewBag.Edificio = edificio;
            return View("index");
        }

        public ActionResult Vender()
        {
            //implementar venta
            return View();
        }
    }
}