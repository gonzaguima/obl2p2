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
        //listado de apartamentos para vista
        public ActionResult MostrarApartamentos(string edificio)
        {
            ViewBag.Apartamento = Sistema.Instancia.BuscarApartamentos(edificio);
            ViewBag.Edificio = edificio;
            return View("index");
        }
 

        //Crear nueva compra
        public ActionResult Alta(string cliente, string edificio, string apartamento, int costo)
        {

            ViewBag.vendido = "";
            if (cliente != "Seleccione un cliente" && edificio != "Seleccione un edificio" && apartamento != "Seleccione un apartamento" && costo >0)
            {
                if (Sistema.Instancia.AltaVenta(Session["User"].ToString(), apartamento, edificio, cliente, costo))
                {
                    ViewBag.vendido = "Venta realizada";
                }
            }
            else
            {
                ViewBag.vendido = "Revise valores seleccionados";
            }
            return View("index");
        }
    }
}
