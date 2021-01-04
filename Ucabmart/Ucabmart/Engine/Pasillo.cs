using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Pasillo
    {
        public int Codigo { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CodigoTienda { get; set; }
        public int CodigoEmpleado { get; set; }

        public Pasillo(int codigo, int numero, string nombre, string descripcion, Tienda tienda, Empleado empleado)
        {
            Codigo = codigo;
            Numero = numero;
            Nombre = nombre;
            Descripcion = descripcion;
            CodigoTienda = tienda.Codigo;
            CodigoEmpleado = empleado.Codigo;
        }

        public Tienda Tienda()
        {
            DBConnection connection = new DBConnection();
            Tienda tienda = null;
            return tienda;
        }
    }
}