
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Punto
    {
        public int Codigo { get; set; }
        public float Valor { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaImplementacion { get; set; }

        public Punto(int codigo, float valor, string descripcion, DateTime fechaimplementacion)
        {
            Codigo = codigo;
            Valor = valor;
            Descripcion = descripcion;
            FechaImplementacion = fechaimplementacion;
        }
    }
}