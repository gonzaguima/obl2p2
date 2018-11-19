using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObligatorioDominio;

namespace Obligatorio2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Usuario c)
        {
            if (Sistema.Instancia.ValidarUser(c)) {
                ViewBag.resultado = "Usuario valido.";
            }
            else { ViewBag.resultado = "Usuario invalido."; }
            return View();
        }
    }
}
