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
            //Session["User"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string user, string pass)
        {
            Vendedor u = Sistema.Instancia.BuscarUsuario(user, pass);
            if (u != null) {
                ViewBag.resultado = "Usuario valido.";
                Session["User"] = user; //Guardo el nombre de usuario de quien se logueo
                Redirect("~/home/index"); //Abro la pagina de inicio
            }
            else { ViewBag.resultado = "Usuario invalido."; }
            return View();
        }
    }
}
