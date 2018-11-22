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
            Session["User"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string user, string pass)
        {
            if (Sistema.Instancia.BuscarUsuario(user, pass) != null) {
                ViewBag.resultado = "Usuario valido.";
                Session["User"] = c.User;
            }
            else { ViewBag.resultado = "Usuario invalido."; }
            return View();
        }
    }
}
