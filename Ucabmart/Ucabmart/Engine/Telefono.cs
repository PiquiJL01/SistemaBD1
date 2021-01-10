using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Telefono : ConexionBD<Telefono, Dictionary<NumeroTelefono, int>>
    {
        #region Atributos
        public Dictionary<NumeroTelefono, int> Numero = null;
        public string Tipo { get; set; }
        public string RifCliente { get; set; }
        public int CodigoPersonaContacto { get; set; }
        public string RifProveedor { get; set; }
        public int CodigoEmpleado { get; set; }
        #endregion

        #region Declaraciones
        public Telefono(int codigoPais, int codigoArea, int numero, TipoTelefono tipo, 
            Cliente cliente)
        {
            Numero = new Dictionary<NumeroTelefono, int>();
            Numero.Add(NumeroTelefono.Pais, codigoPais);
            Numero.Add(NumeroTelefono.Area, codigoArea);
            Numero.Add(NumeroTelefono.Numero, numero);
            switch (tipo)
            {
                case TipoTelefono.Fijo:
                    Tipo = "Fijo";
                    break;
                case TipoTelefono.Movil:
                    Tipo = "Movil";
                    break;
                default:
                    Tipo = null;
                    break;
            }
            RifCliente = cliente.RIF;
            CodigoPersonaContacto = 0;
            RifProveedor = null;
            CodigoEmpleado = 0;
        }

        public Telefono(int codigoPais, int codigoArea, int numero, TipoTelefono tipo,
            PersonaContacto personaContacto)
        {
            Numero = new Dictionary<NumeroTelefono, int>();
            Numero.Add(NumeroTelefono.Pais, codigoPais);
            Numero.Add(NumeroTelefono.Area, codigoArea);
            Numero.Add(NumeroTelefono.Numero, numero);
            switch (tipo)
            {
                case TipoTelefono.Fijo:
                    Tipo = "Fijo";
                    break;
                case TipoTelefono.Movil:
                    Tipo = "Movil";
                    break;
                default:
                    Tipo = null;
                    break;
            }
            RifCliente = null;
            CodigoPersonaContacto = personaContacto.Codigo;
            RifProveedor = null;
            CodigoEmpleado = 0;
        }

        public Telefono(int codigoPais, int codigoArea, int numero, TipoTelefono tipo,
            Proveedor proveedor)
        {
            Numero = new Dictionary<NumeroTelefono, int>();
            Numero.Add(NumeroTelefono.Pais, codigoPais);
            Numero.Add(NumeroTelefono.Area, codigoArea);
            Numero.Add(NumeroTelefono.Numero, numero);
            switch (tipo)
            {
                case TipoTelefono.Fijo:
                    Tipo = "Fijo";
                    break;
                case TipoTelefono.Movil:
                    Tipo = "Movil";
                    break;
                default:
                    Tipo = null;
                    break;
            }
            RifCliente = null;
            CodigoPersonaContacto = 0;
            RifProveedor = proveedor.RIF;
            CodigoEmpleado = 0;
        }

        public Telefono(int codigoPais, int codigoArea, int numero, TipoTelefono tipo,
            Empleado empleado)
        {
            CodigoPais = codigoPais;
            CodigoArea = codigoArea;
            Numero = numero;
            switch (tipo)
            {
                case TipoTelefono.Fijo:
                    Tipo = "Fijo";
                    break;
                case TipoTelefono.Movil:
                    Tipo = "Movil";
                    break;
                default:
                    Tipo = null;
                    break;
            }
            RifCliente = null;
            CodigoPersonaContacto = 0;
            RifProveedor = null;
            CodigoEmpleado = 0;
        }

        public Telefono(int codigoPais, int codigoArea, int numero)
        {
            Dictionary<NumeroTelefono, int> diccionario = new Dictionary<NumeroTelefono, int>();
            diccionario.Add(NumeroTelefono.Pais, codigoPais);
            diccionario.Add()
            Telefono telefono = Leer(diccionario);
        }
    }
}