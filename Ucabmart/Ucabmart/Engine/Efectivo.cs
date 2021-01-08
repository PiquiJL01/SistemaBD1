using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Efectivo : MetodoDePago
    {
        public string CodigoMoneda { get; set; }

        public Efectivo(int codigo, string nombre, string descripcion, DateTime fecha, Moneda moneda)
            : base(codigo, nombre, descripcion, fecha)
        {
            CodigoMoneda = moneda.Codigo;
        }
    }
}