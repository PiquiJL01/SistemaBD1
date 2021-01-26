using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Asistencia : ConexionBD<Asistencia, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public string Dia { get; set; }
        public int CodigoEmpleado { get; set; }
        public int CodigoHorario { get; set; }
        #endregion


        #region Declaraciones
        private Asistencia(int codigo, DateTime fecha, TimeSpan horaEntrada, TimeSpan horaSalida, string dia, int empleado, int horario)
        {
            Codigo = codigo;
            Fecha = fecha;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
            Dia = dia;
            CodigoEmpleado = empleado;
            CodigoHorario = horario;
        }

        public Asistencia(DateTime fecha, TimeSpan horaEntrada, TimeSpan horaSalida, DayOfWeek dia, Empleado empleado, Horario horario)
        {
            Fecha = fecha;
            HoraEntrada = horaEntrada;
            HoraSalida = horaSalida;
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
            CodigoEmpleado = empleado.Codigo;
            CodigoHorario = horario.Codigo;
        }

        public Asistencia(int codigo)
        {
            Asistencia asistencia = Leer(codigo);
            if (!(asistencia == null))
            {
                Codigo = asistencia.Codigo;
                Fecha = asistencia.Fecha;
                HoraEntrada = asistencia.HoraEntrada;
                HoraSalida = asistencia.HoraSalida;
                Dia = asistencia.Dia;
                CodigoEmpleado = asistencia.CodigoEmpleado;
                CodigoHorario = asistencia.CodigoHorario;
            }
            else
            {
                Codigo = 0;
                Fecha = new DateTime();
                HoraEntrada = new TimeSpan();
                HoraSalida = new TimeSpan();
                Dia = null;
                CodigoEmpleado = 0;
                CodigoHorario = 0;
            }
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO asistencia (as_fecha, as_hora_entrada, as_hora_salida, as_dia, empleado_em_codigo, horario_ho_codigo) " +
                    "VALUES (@fecha, @entrada, @salida, @dia, @empleado, @horario) RETURNING as_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("fecha", Fecha);
                Script.Parameters.AddWithValue("entrada", HoraEntrada);
                Script.Parameters.AddWithValue("salida", HoraSalida);
                Script.Parameters.AddWithValue("dia", Dia);
                Script.Parameters.AddWithValue("empleado", CodigoEmpleado);
                Script.Parameters.AddWithValue("horario", CodigoHorario);

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

        public override Asistencia Leer(int codigo)
        {
            Asistencia asistencia = null;

            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM tabla WHERE codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    asistencia = new Asistencia(ReadInt(0), ReadDate(1), ReadTime(2), ReadTime(3), ReadString(4), ReadInt(5), ReadInt(6));
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
                return null;
            }

            return asistencia;
        }

        public override List<Asistencia> Todos()
        {
            List<Asistencia> lista = new List<Asistencia>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM asistencia";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Asistencia asistencia = new Asistencia(ReadInt(0), ReadDate(1), ReadTime(2), ReadTime(3), ReadString(4), ReadInt(5), ReadInt(6));

                    lista.Add(asistencia);
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

                string Comando = "UPDATE asistencia SET as_fecha = @fecha, as_hora_entrada = @entrada, as_hora_salida = @salida, as_dia = @dia, empleado_em_codigo = @empleado, horario_ho_codigo = @horario " +
                    "WHERE codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("fecha", Fecha);
                Script.Parameters.AddWithValue("entrada", HoraEntrada);
                Script.Parameters.AddWithValue("salida", HoraSalida);
                Script.Parameters.AddWithValue("dia", Dia);
                Script.Parameters.AddWithValue("empleado", CodigoEmpleado);
                Script.Parameters.AddWithValue("horario", CodigoHorario);

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

                string Commando = "DELETE FROM asistencia WHERE codigo = @codigo";
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