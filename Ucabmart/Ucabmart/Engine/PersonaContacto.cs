using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class PersonaContacto
    {
        public string Codigo { get; set; }
        public string Cedula { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string CodigoClienteJuridico { get; set; }
        public string RifProveedor { get; set; }

        public PersonaContacto(string codigo, string cedula, string nombre1, string nombre2,
            string apellido1, string apellido2, Juridico cliente)
        {
            Codigo = codigo;
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            CodigoClienteJuridico = cliente.Codigo;
            RifProveedor = null;
        }

        public PersonaContacto(string codigo, string cedula, string nombre1, string nombre2,
            string apellido1, string apellido2, Proveedor proveedor)
        {
            Codigo = codigo;
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            CodigoClienteJuridico = null;
            RifProveedor = proveedor.RIF;
        }

        public Juridico Juridico()
        {
            DBConnection connection = new DBConnection();
            Juridico juridico = null;
            return juridico;
        }
    }
}