using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Efectivo : MetodoDePago
    {
        public int Moneda { get; set; }

        public Efectivo(int codigo, string nombre, string descripcion, DateTime fecha, int moneda)
            : base(codigo, nombre, descripcion, fecha)
        {
            Moneda = moneda;
        }
    }
}