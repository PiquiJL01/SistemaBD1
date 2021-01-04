using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool EsAlimenticio { get; set; }
        public float Precio { get; set; }
        public string Calidad { get; set; }
        public string Descripcion { get; set; }
        public int CodigoMarca { get; set; }
        public int CodigoClasificacion { get; set; }

        public Producto(string codigo, string nombre, bool esAlimenticio, float precio, TipoCalidad calidad, 
            string descrpcion, Marca marca, Clasificacion clasificacion)
        {
            Codigo = codigo;
            Nombre = nombre;
            EsAlimenticio = esAlimenticio;
            Precio = precio;
            switch (calidad)
            {
                case TipoCalidad.Alta:
                    Calidad = "Alta";
                    break;
                case TipoCalidad.Baja:
                    Calidad = "Baja";
                    break;
                case TipoCalidad.Regular:
                    Calidad = "Regular";
                    break;
                default:
                    Calidad = null;
                    break;
            }
            Descripcion = descrpcion;
            CodigoMarca = marca.Codigo;
            CodigoClasificacion = clasificacion.Codigo;
        }
    }
}