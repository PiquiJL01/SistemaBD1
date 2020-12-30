using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class PeriodoVacional
    {
        public string Codigo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int Empleado { get; set; }

        public PeriodoVacional(string codigo, DateTime fechaInicio, DateTime fechaFinal, int empleado)
        {
            Codigo = codigo;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
            Empleado = empleado;
        }
    }
}