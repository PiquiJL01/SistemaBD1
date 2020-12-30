using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class PersonaContacto
    {
        public string Cliente { get; set; }
        public string Codigo { get; set; }
        public string Cedula { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string RIF { get; set; }

        public PersonaContacto(string cliente, string codigo, string cedula, string nombre1, string nombre2,
            string apellido1, string apellido2, string rif)
        {
            Cliente = cliente;
            Codigo = codigo;
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            RIF = rif;
        }
    }
}