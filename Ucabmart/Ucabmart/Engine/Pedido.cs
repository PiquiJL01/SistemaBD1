using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Pedido
    {
        public string Codigo { get; set; }
        public string Cliente { get; set; }
        public float MontoTotal { get; set; }
        public DateTime Fecha { get; set; }
        public bool EstaAprovado { get; set; }
        public bool EsEnLinea { get; set; }
        public int MetodoDePago { get; set; }
        public string Proveedor { get; set; }
        public int Cajero { get; set; }

        public Pedido(string codigo, string cliente, float montoTotal, DateTime fecha, bool estaAprovado, bool esEnLinea,
            int metodoDePago, string proveedor, int cajero)
        {
            Codigo = codigo;
            Cliente = cliente;
            MontoTotal = montoTotal;
            Fecha = fecha;
            EstaAprovado = estaAprovado;
            EsEnLinea = esEnLinea;
            MetodoDePago = metodoDePago;
            Proveedor = proveedor;
            Cajero = cajero;
        }
    }
}