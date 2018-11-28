﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioDominio
{
    public class Vendedor
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public Vendedor(string user, string pass)
        {
            this.User = user;
            this.Pass = pass;
        }
        public override string ToString()
        {
            return this.User;
        }
    }
}
