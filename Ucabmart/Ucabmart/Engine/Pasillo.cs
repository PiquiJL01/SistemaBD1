using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Pasillo
    {
        public int Codigo { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Tienda { get; set; }
        public int Empleado { get; set; }

        public Pasillo(int codigo, int numero, string nombre, string descripcion, int tienda, int empleado)
        {
            Codigo = codigo;
            Numero = numero;
            Nombre = nombre;
            Descripcion = descripcion;
            Tienda = tienda;
            Empleado = empleado;
        }
    }
}