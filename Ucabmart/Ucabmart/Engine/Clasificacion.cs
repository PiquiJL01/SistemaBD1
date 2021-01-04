using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Clasificacion
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Clasificacion(int codigo, string nombre, string descripción)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripción;
        }
    }
}