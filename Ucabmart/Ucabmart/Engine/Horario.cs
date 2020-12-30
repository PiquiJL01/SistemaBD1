using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Horario
    {
        public int Codigo { get; set; }
        public TimeSpan HoraEntradaSalida { get; set; }
        public string Turno { get; set; }
        public DayOfWeek Dia { get; set; }

        public Horario(int codigo, TimeSpan horaEntradaSalida, TipoTurno turno, DayOfWeek dia)
        {
            Codigo = codigo;
            HoraEntradaSalida = horaEntradaSalida;
            switch (turno)
            {
                case TipoTurno.Diurno:
                    Turno = "Diurno";
                    break;
                case TipoTurno.Matutino:
                    Turno = "Matutino0";
                    break;
                case TipoTurno.Vespertino:
                    Turno = "Vespertino";
                    break;
                case TipoTurno.Nocturno:
                    Turno = "Nocturno";
                    break;
                default:
                    Turno = null;
                    break;
            }
        }
    }
}