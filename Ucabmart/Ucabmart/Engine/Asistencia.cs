using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Asistencia
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntradaSalida { get; set; }
        public DayOfWeek Dia { get; set; }
        public int CodigoEmpleado { get; set; }
        public int CodigoHorario { get; set; }

        public Asistencia(int codigo, DateTime fecha, TimeSpan horaEntradaSalida, DayOfWeek dia, Empleado empleado, Horario horario)
        {
            Codigo = codigo;
            Fecha = fecha;
            HoraEntradaSalida = horaEntradaSalida;
            Dia = dia;
            CodigoEmpleado = empleado.Codigo;
            CodigoHorario = horario.Codigo;
        }
    }
}