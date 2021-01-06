using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public abstract class Cliente
    {
        public string RIF { get; set; }
        public string CodigoCorreoElectronico { get; set; }
        public int CodigoTienda { get; set; }

        public Cliente(string rif, CorreoElectronico correo, Tienda tienda)
        {
            RIF = rif;
            CodigoCorreoElectronico = correo.Codigo;
            CodigoTienda = tienda.Codigo;
        }
    }
}