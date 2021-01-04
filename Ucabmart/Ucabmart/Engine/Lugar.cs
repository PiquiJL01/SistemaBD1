using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Lugar
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string CodigoUbicacion { get; set; }

        public Lugar(string codigo, string nombre, TipoLugar tipo, string descripcion, Lugar ubicacion = null)
        {
            Codigo = codigo;
            Nombre = nombre;
            switch (tipo)
            {
                case TipoLugar.Direccion:
                    Tipo = "Dirección";
                    break;
                case TipoLugar.Estado:
                    Tipo = "Estado";
                    break;
                case TipoLugar.Municipio:
                    Tipo = "Municipio";
                    break;
                case TipoLugar.Pais:
                    Tipo = "País";
                    break;
                case TipoLugar.Parroquia:
                    Tipo = "Parroquia";
                    break;
                default:
                    Tipo = null;
                    break;
            }
            Descripcion = descripcion;
            if (ubicacion == null)
            {
                CodigoUbicacion = null;
            }
            else
            {
                CodigoUbicacion = ubicacion.Codigo;
            }
        }
    }
}