using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Empleado
    {
        public int Codigo { get; set; }
        public string Password { get; set; }
        public string RIF { get; set; }
        public string Cedula { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int CodigoDepartamento { get; set; }
        public int CodigoTienda { get; set; }
        public int CodigoJefe { get; set; }
        public string CodigoDireccion { get; set; }

        public Empleado(int codigo, string password, string rif, string cedula, string nombre1, string nombre2, string apellido1, string apellido2,
            int departamento, int tienda, int jefe, string direccion)
        {
            Codigo = codigo;
            Password = password;
            RIF = rif;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            CodigoDepartamento = departamento;
            CodigoTienda = tienda;
            CodigoJefe = jefe;
            CodigoDireccion = direccion;
        }
    }
}