using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioDominio
{
    public class Vendedor : Usuario
    {
        public List<Compra> Ventas { get; set; } = new List<Compra>();
        //Ver que atributos necesita. Sldos
        public Vendedor(string user, string pass) : base(user, pass) { }
    }
}
