﻿using System;
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
            List<Compra> ventas = Sistema.Instancia.ListaVentas(Session["User"].ToString());
            if (ventas.Count > 0)
            {
                ViewBag.listado = ventas;
            }
            else { ViewBag.listado = "El usuario debe ser vendedor"; }
            return View();
        }
    }
}
