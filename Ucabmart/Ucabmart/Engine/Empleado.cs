using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Empleado
    {
        public int Codigo { get; set; }
        public string RIF { get; set; }
        public string Cedula { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Departamento { get; set; }
        public int Tienda { get; set; }
        public int Jefe { get; set; }
        public string Direccion { get; set; }

        public Empleado(int codigo, string rif, string cedula, string nombre1, string nombre2, string apellido1, string apellido2,
            int departamento, int tienda, int jefe, string direccion)
        {
            Codigo = codigo;
            RIF = rif;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Departamento = departamento;
            Tienda = tienda;
            Jefe = jefe;
            Direccion = direccion;
        }
    }
}