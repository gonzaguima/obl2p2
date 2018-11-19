using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}
