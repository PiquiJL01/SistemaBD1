using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public abstract class Cliente
    {
        public string Codigo { get; set; }
        public string RIF { get; set; }
        public string CodigoCorreoElectronico { get; set; }
        public int CodigoTienda { get; set; }

        public Cliente(string codigo, string rif, CorreoElectronico correo, Tienda tienda)
        {
            Codigo = codigo;
            RIF = rif;
            CodigoCorreoElectronico = correo.Codigo;
            CodigoTienda = tienda.Codigo;
        }

        public CorreoElectronico CorreoElectronico()
        {
            DBConnection connection = new DBConnection();
            CorreoElectronico correo = null;
            return correo;
        }

        public Tienda Tienda()
        {
            DBConnection connection = new DBConnection();
            Tienda tienda = null;
            return tienda;
        }
    }
}