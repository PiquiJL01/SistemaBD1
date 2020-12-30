using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Telefono
    {
        public int CodigoPais { get; set; }
        public int CodigoArea { get; set; }
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public string Cliente { get; set; }
        public string PersonaContacto { get; set; }
        public string Proveedor { get; set; }
        public int Empleado { get; set; }

        public Telefono(int codigoPais, int codigoArea, int numero, string tipo, string cliente, string personaContacto,
            string proveedor, int empleado)
        {
            CodigoPais = codigoPais;
            CodigoArea = codigoArea;
            Numero = numero;
            Tipo = tipo;
            Cliente = cliente;
            PersonaContacto = personaContacto;
            Proveedor = proveedor;
            Empleado = empleado;
        }
    }
}