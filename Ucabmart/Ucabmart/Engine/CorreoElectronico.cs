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
        public string RifProveedor { get; set; }
        public int CodigoEmpleado { get; set; }

        public CorreoElectronico(string codigo, string direccion, Proveedor proveedor, Empleado empleado)
        {
            Codigo = codigo;
            Direccion = direccion;
            RifProveedor = proveedor.RIF;
            CodigoEmpleado = empleado.Codigo;
        }

        public CorreoElectronico(string codigo, string direccion, Empleado empleado)
        {
            Codigo = codigo;
            Direccion = direccion;
            RifProveedor = null;
            CodigoEmpleado = empleado.Codigo;
        }

        public CorreoElectronico(string codigo, string direccion, Proveedor proveedor)
        {
            Codigo = codigo;
            Direccion = direccion;
            RifProveedor = proveedor.RIF;
            CodigoEmpleado = 0;
        }

        public Proveedor Proveedor()
        {
            DBConnection connection = new DBConnection();
            Proveedor proveedor = null;
            return proveedor;
        }
    }
}