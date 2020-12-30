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

        public Juridico(string codigo, string rif, string email, int tienda, string denominacionComercial,
            string razonSocial, float capital, string paginaWeb, string direccionFisica, string direccionFiscal)
            : base(codigo, rif, email, tienda)
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