using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obligatorio2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //if (Session["User"] != null)
            //{
                return View();
            //}
            //else { return View("~/Login"); }
        }
        public ActionResult ABMCliente() { return View("~/ABMCliente"); }
        public ActionResult ListCliente() { return View("~/ListadoClientes"); }
        public ActionResult Venta() { return View("~/Venta"); }
    }
}
