using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Proveedor
    {
        public string RIF { get; set; }
        public string RazonSocial { get; set; }
        public string DenominacionComercial { get; set; }
        public string PaginaWeb { get; set; }
        public string DireccionFisica { get; set; }
        public string DireccionFiscal { get; set; }

        public Proveedor(string rif, string razonSocial, string denominacionComercial, string paginaWeb,
            string direccionFisica, string direccionFiscal)
        {
            RIF = rif;
            RazonSocial = razonSocial;
            DenominacionComercial = denominacionComercial;
            PaginaWeb = paginaWeb;
            DireccionFisica = direccionFisica;
            DireccionFiscal = direccionFiscal;
        }
    }
}