using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Canje : MetodoDePago
    {
        public Canje(int codigo, string nombre, string descripcion, DateTime fecha) : base(codigo, nombre, descripcion, fecha)
        {

        }
    }
}