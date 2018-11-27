using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObligatorioDominio;

namespace Obligatorio2.Controllers
{
    public class ListadoVentaController : Controller
    {
        // GET: ListadoVenta
        public ActionResult Index()
        {
            if (Session["User"] is Vendedor)
            {
                Vendedor v = Sistema.Instancia.BuscarUsuarioV(Session["User"]);
                //v.Sort();
                ViewBag.listado = v;
            }
            else { ViewBag.listado = "El usuario debe ser vendedor"; }
            return View();
        }
    }
}