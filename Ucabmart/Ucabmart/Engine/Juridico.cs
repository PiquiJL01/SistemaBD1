using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Juridico : Cliente
    {
        public string DenominacionComercial { get; set; }
        public string RazonSocial { get; set; }
        public float Capital { get; set; }
        public string PaginaWeb { get; set; }
        public string DireccionFisica { get; set; }
        public string DireccionFiscal { get; set; }

        public Juridico(string rif, CorreoElectronico correo, Tienda tienda, string denominacionComercial,
            string razonSocial, float capital, string paginaWeb, string direccionFisica, string direccionFiscal)
            : base(rif, correo, tienda)
        {
            DenominacionComercial = denominacionComercial;
            RazonSocial = razonSocial;
            Capital = capital;
            PaginaWeb = paginaWeb;
            DireccionFisica = direccionFisica;
            DireccionFiscal = direccionFiscal;
        }
    }
}