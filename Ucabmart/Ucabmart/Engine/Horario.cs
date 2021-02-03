using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Horario : ConexionBD<Horario, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public string Turno { get; set; }
        public string Dia { get; set; }
        #endregion

        #region Declaraciones
        public Horario(TimeSpan horaEntrada, TimeSpan horaSalida, TipoTurno turno, DayOfWeek dia)
        {
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            switch (turno)
            {
                case TipoTurno.Diurno:
                    Turno = "Diurno";
                    break;
                case TipoTurno.Matutino:
                    Turno = "Matutino";
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
            switch (dia)
            {
                case DayOfWeek.Sunday:
                    Dia = "Domingo";
                    break;
                case DayOfWeek.Monday:
                    Dia = "Lunes";
                    break;
                case DayOfWeek.Tuesday:
                    Dia = "Martes";
                    break;
                case DayOfWeek.Wednesday:
                    Dia = "Miercoles";
                    break;
                case DayOfWeek.Thursday:
                    Dia = "Jueves";
                    break;
                case DayOfWeek.Friday:
                    Dia = "Viernes";
                    break;
                case DayOfWeek.Saturday:
                    Dia = "Sabado";
                    break;
                default:
                    break;
            }
        }

        public Horario(int codigo)
        {
            Horario horario = Leer(codigo);
            if (!(horario == null))
            {
                Codigo = horario.Codigo;
                HoraEntrada = horario.HoraEntrada;
                HoraSalida = horario.HoraSalida;
                Turno = horario.Turno;
                Dia = horario.Dia;
            }
        }

        private Horario(int codigo, TimeSpan horaEntrada, TimeSpan horaSalida, string turno, string dia)
        {
            Codigo = codigo;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            Turno = turno;
            Dia = dia;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO horario (ho_hora_inicio, ho_hora_salida, ho_turno, ho_dia) " +
                    "VALUES (@inicio, @salida, @turno, @dia) RETURNING ho_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("inicio", HoraEntrada);
                Script.Parameters.AddWithValue("salida", HoraSalida);
                Script.Parameters.AddWithValue("turno", Turno);
                Script.Parameters.AddWithValue("dia", Dia);

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    Codigo = ReadInt(0);
                }

                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }

        public override Horario Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM horario WHERE ho_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Horario(ReadInt(0), ReadTime(1), ReadTime(2), ReadString(3), ReadString(4));
                }

                Conexion.Close();
            }
            catch (Exception e)
            {
                try
                {
                    Conexion.Close();
                }
                catch (Exception f)
                {

                }
            }

            return null;
        }

        public override List<Horario> Todos()
        {
            List<Horario> lista = new List<Horario>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM horario";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Horario horario = new Horario(ReadInt(0), ReadTime(1), ReadTime(2), ReadString(3),
                        ReadString(4));

                    lista.Add(horario);
                }
            }
            catch (Exception e)
            {
                try
                {
                    Conexion.Close();
                }
                catch (Exception f)
                {

                }
                return null;
            }

            return lista;
        }

        public override void Actualizar()
        {
            try
            {
                Conexion.Open();

                string Comando = "UPDATE horario SET ho_hora_inicio = @inicio, ho_hora_salida = @salida, " +
                    "ho_turno = @turno, ho_dia = @dia WHERE ho_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("inicio", HoraEntrada);
                Script.Parameters.AddWithValue("salida", HoraSalida);
                Script.Parameters.AddWithValue("turno", Turno);
                Script.Parameters.AddWithValue("dia", Dia);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                try
                {
                    Conexion.Close();
                }
                catch (Exception f)
                {

                }
            }
        }

        public override void Eliminar()
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM horario WHERE ho_codigo = @codigo";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                try
                {
                    Conexion.Close();
                }
                catch (Exception f)
                {

                }
            }
        }
        #endregion
    }
}