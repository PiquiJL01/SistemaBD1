using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Almacen
    {
        public int Codigo { get; set; }
        public int codigoTienda { get; set; }

        public Almacen(int codigo, Tienda tienda)
        {
            Codigo = codigo;
            codigoTienda = tienda.Codigo;
        }

        public Tienda Tienda()
        {
            DBConnection connection = new DBConnection();
            Tienda tienda = null; //connection.BuscarTienda(codigoTienda);

            return tienda;
        }
    }
}