using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Cheque : MetodoDePago
    {
        public string Numero { get; set; }

        public Cheque(int codigo, string nombre, string descripcion, DateTime fecha, string numero)
            : base(codigo, nombre, descripcion, fecha)
        {
            Numero = numero;
        }
    }
}