using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class MetodoDePago : ConexionBD<MetodoDePago, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        #endregion

        #region Declaraciones
        public MetodoDePago(string nombre, string descripcion, DateTime fecha)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Fecha = fecha;
        }

        private MetodoDePago(int codigo, string nombre, string descripcion, DateTime fecha)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Fecha = fecha;
        }

        public MetodoDePago(int codigo)
        {
            MetodoDePago metodoDePago = Leer(codigo);
            if (!(metodoDePago == null))
            {
                Codigo = metodoDePago.Codigo;
                Nombre = metodoDePago.Nombre;
                Descripcion = metodoDePago.Descripcion;
                Fecha = metodoDePago.Fecha;
            }
        }

        public MetodoDePago() { }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO metodo_de_pago (mp_nombre, mp_descripcion, mp_fecha) " +
                    "VALUES (@nombre, @descripcion, @fecha) RETURNING mp_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);
                Script.Parameters.AddWithValue("fecha", Fecha);

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

        public override MetodoDePago Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM metodo_de_pago WHERE mp_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new MetodoDePago(ReadInt(0), ReadString(1), ReadString(2), ReadDate(3));
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

        public override List<MetodoDePago> Todos()
        {
            List<MetodoDePago> lista = new List<MetodoDePago>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM metodo_de_pago";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    MetodoDePago metodoDePago = new MetodoDePago(ReadInt(0), ReadString(1), ReadString(2), ReadDate(3));

                    lista.Add(metodoDePago);
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

                string Comando = "UPDATE tabla SET mp_nombre = @nombre, mp_descripcion = @descripcion, mp_fecha = @fecha " +
                    "WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);
                Script.Parameters.AddWithValue("fecha", Fecha);

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

                string Commando = "DELETE FROM metodo_de_pago WHERE mp_codigo = @codigo";
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