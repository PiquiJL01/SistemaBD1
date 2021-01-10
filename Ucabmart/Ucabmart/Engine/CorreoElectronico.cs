using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class CorreoElectronico
    {
        public int Codigo { get; set; }
        public string Direccion { get; set; }

        public CorreoElectronico(int codigo, string direccion)
        {
            Codigo = codigo;
            Direccion = direccion;
        }

        public CorreoElectronico(string direccion)
        {
            Direccion = direccion;
        }
    }





}