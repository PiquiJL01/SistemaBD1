using System;

namespace Ucabmart.Engine
{
    public class Pedido
    {
        public string Codigo { get; set; }
        public float MontoTotal { get; set; }
        public DateTime Fecha { get; set; }
        public bool EstaAprovado { get; set; }
        public string CodigoCliente { get; set; }
        public bool EsEnLinea { get; set; }
        public int MetodoDePago { get; set; }
        public string Proveedor { get; set; }
        public int Cajero { get; set; }

        public Pedido(string codigo, string cliente, float montoTotal, DateTime fecha, bool estaAprovado, bool esEnLinea,
            int metodoDePago, string proveedor, int cajero)
        {
            Codigo = codigo;
            CodigoCliente = cliente;
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