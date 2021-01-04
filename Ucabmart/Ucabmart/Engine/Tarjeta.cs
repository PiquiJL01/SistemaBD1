using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Tarjeta : MetodoDePago
    {
        public string Tipo { get; set; }
        public int Numero { get; set; }
        public int CVV { get; set; }
        public string NombreImpreso { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Tarjeta(int codigo, string nombre, string descripcion, DateTime fecha,TipoTarjeta tipo,
            int numero, int cvv, string nombreimpreso, DateTime fechaVencimiento)
            : base(codigo, nombre, descripcion, fecha)
        {
            switch (tipo)
            {
                case TipoTarjeta.AmericanExpress:
                    Tipo = "American Express";
                    break;
                case TipoTarjeta.Debito:
                    Tipo = "Debito";
                    break;
                case TipoTarjeta.DinersClub:
                    Tipo = "Diner´s Club";
                    break;
                case TipoTarjeta.Discovery:
                    Tipo = "Discovery";
                    break;
                case TipoTarjeta.Maestro:
                    Tipo = "Maestro";
                    break;
                case TipoTarjeta.MasterCard:
                    Tipo = "MasterCard";
                    break;
                case TipoTarjeta.Visa:
                    Tipo = "Visa";
                    break;
                default:
                    Tipo = null;
                    break;
            }
            Numero = numero;
            CVV = cvv;
            NombreImpreso = nombreimpreso;
            FechaVencimiento = fechaVencimiento;
        }
    }
}