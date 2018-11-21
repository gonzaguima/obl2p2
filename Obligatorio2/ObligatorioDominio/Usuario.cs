using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioDominio
{
    public abstract class Usuario
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public Usuario(string user, string pass)
        {
            this.User = user;
            this.Pass = pass;
        }
        public bool ValidarUser()
        {
            bool existe = false;
            return existe;
        }
    }
}
