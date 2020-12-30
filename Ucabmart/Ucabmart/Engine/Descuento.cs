using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Descuento
    {
        public int Codigo { get; set; }
        public float Porcentaje { get; set; }
        public string Descripcion { get; set; }

        public Descuento(int codigo, float porcentaje, string descripcion)
        {
            Codigo = codigo;
            Porcentaje = porcentaje;
            Descripcion = descripcion;
        }
    }
}