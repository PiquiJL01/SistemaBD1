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
        public int CodigoTienda { get; set; }
        public int CodigoPasillo { get; set; }
        public int CodigoAlmacen { get; set; }

        public Zona(string codigo, string nombre, Tienda tienda, Pasillo pasillo)
        {
            Codigo = codigo;
            Nombre = nombre;
            CodigoTienda = tienda.Codigo;
            CodigoPasillo = pasillo.Codigo;
            CodigoAlmacen = -1;
        }

        public Zona(string codigo, string nombre, Tienda tienda, Almacen almacen)
        {
            Codigo = codigo;
            Nombre = nombre;
            CodigoTienda = tienda.Codigo;
            CodigoPasillo = -1;
            CodigoAlmacen = almacen.Codigo;
        }
    }
}