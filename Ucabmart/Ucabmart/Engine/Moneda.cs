using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Moneda
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Moneda(string codigo, string nombre, float tasaDeCambio, DateTime fechaImplementacion, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
           // TasaDeCambio = tasaDeCambio;
            //FechaImplementacion = fechaImplementacion;
            Descripcion = descripcion;
        }
    }
}