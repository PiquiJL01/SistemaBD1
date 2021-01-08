using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Tienda
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }

        public Tienda(int codigo, string nombre, string descripcion, string direccion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Direccion = direccion;
        }

        public Tienda(int codigo) 
        {
            
        }
    }
}