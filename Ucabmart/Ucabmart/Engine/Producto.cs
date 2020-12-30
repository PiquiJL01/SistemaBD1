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
        public int Marca { get; set; }

        public Producto(string codigo, string nombre, bool esAlimenticio, float precio, TipoCalidad calidad, 
            string descrpcion, int marca)
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
            Marca = marca;
        }
    }
}