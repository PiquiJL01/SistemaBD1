using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Zona
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public Zona(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }
    }
}