using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Natural : Cliente
    {
        public string Cedula { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }

        public Natural(string codigo, string rif, string email, int tienda, string cedula,
            string nombre1, string nombre2, string apellido1, string apellido2, string direccion)
            : base(codigo, rif, email, tienda)
        {
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Direccion = direccion;
        }
    }
}