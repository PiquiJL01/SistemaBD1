using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class CorreoElectronico
    {
        public string Codigo { get; set; }
        public string Direccion { get; set; }
        public string Cliente { get; set; }
        public string Proveedor { get; set; }
        public int Empleado { get; set; }

        public CorreoElectronico(string codigo, string direccion, string cliente, string proveedor, int empleado)
        {
            Codigo = codigo;
            Direccion = direccion;
            Cliente = cliente;
            Proveedor = proveedor;
            Empleado = empleado;
        } 
    }
}