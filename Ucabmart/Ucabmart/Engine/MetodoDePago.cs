using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public abstract class MetodoDePago
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public MetodoDePago(int codigo, string nombre, string descripcion, DateTime fecha)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Fecha = fecha;
        }
    }
}