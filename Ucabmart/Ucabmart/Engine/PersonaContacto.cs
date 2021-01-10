using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class PersonaContacto
    {
        public int Codigo { get; set; }
        public string Cedula { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string RifClienteJuridico { get; set; }
        public string RifProveedor { get; set; }

        public PersonaContacto(int codigo, string cedula, string nombre1, string nombre2,
            string apellido1, string apellido2, Juridico cliente)
        {
            Codigo = codigo;
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            RifClienteJuridico = cliente.RIF;
            RifProveedor = null;
        }

        public PersonaContacto(int codigo, string cedula, string nombre1, string nombre2,
            string apellido1, string apellido2, Proveedor proveedor)
        {
            Codigo = codigo;
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            RifClienteJuridico = null;
            RifProveedor = proveedor.RIF;
        }
    }
}