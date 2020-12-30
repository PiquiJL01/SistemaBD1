using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public abstract class Cliente
    {
        public string Codigo { get; set; }
        public string RIF { get; set; }
        public string Email { get; set; }
        public int Tienda { get; set; }

        public Cliente(string codigo, string rif, string email, int tienda)
        {
            Codigo = codigo;
            RIF = rif;
            Email = email;
            Tienda = tienda;
        }
    }
}