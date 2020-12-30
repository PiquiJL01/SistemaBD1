using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Estatus
    {
        public int Codigo { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public Estatus(int codigo, string tipo, DateTime fecha, string descripcion)
        {
            Codigo = codigo;
            Tipo = tipo;
            Fecha = fecha;
            Descripcion = descripcion;
        }
    }
}