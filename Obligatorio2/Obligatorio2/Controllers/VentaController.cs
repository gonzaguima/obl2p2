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
        public ActionResult Alta(string documentoCliente, string nombreEdificio, string numeroApartamento)
        {
            ViewBag.vendido = "";
            if (documentoCliente != "Seleccione un cliente" && nombreEdificio != "Seleccione un edificio" && numeroApartamento != "Seleccione un apartamento")
            {
                DateTime fecha = DateTime.Now;
                string nombreVendedor = (string)(Session["User"]);
                Vendedor vendedor = Sistema.Instancia.BuscarVendedor(nombreVendedor);
                Apartamento apartamento = Sistema.Instancia.buscarApto(numeroApartamento);
                Cliente cliente = Sistema.Instancia.BuscarCliente(documentoCliente);
                int precio = apartamento.PrecioBase;
                cliente.Compras.Add(new Compra(fecha, vendedor, precio, apartamento, cliente));
                ViewBag.vendido = "Venta realizada";
            }
            else
            {
                ViewBag.vendido = "Revise valores seleccionados";
            }
            return View();
        }
    }
}