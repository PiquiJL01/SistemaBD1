using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Almacen
    {
        public int Codigo { get; set; }

        public Almacen(int codigo)
        {
            Codigo = codigo;
        }
    }
}