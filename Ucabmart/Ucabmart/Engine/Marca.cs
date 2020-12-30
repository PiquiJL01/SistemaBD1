using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Marca
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool EsPropia { get; set; }
        public string Descripcion { get; set; }

        public Marca(int codigo, string nombre, bool esPropia, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            EsPropia = esPropia;
            Descripcion = descripcion;
        }
    }
}