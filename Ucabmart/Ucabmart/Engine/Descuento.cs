using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Descuento : ConexionBD<Descuento, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public float Porcentaje { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Declaraciones
        public Descuento(float porcentaje, string descripcion)
        {
            Porcentaje = porcentaje;
            Descripcion = descripcion;
        }

        public Descuento(int codigo)
        {
            Descuento descuento = Leer(codigo);
            if (!(descuento == null))
            {
                Codigo = descuento.Codigo;
                Porcentaje = descuento.Porcentaje;
                Descripcion = descuento.Descripcion;
            }
        }

        private Descuento(int codigo, float porcentaje, string descripcion)
        {
            Codigo = codigo;
            Porcentaje = porcentaje;
            Descripcion = descripcion;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO descuento (de_porcentaje, de_descripcion) VALUES (@porcentaje, @descripcion) RETURNING de_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("porcentaje", Porcentaje);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

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

        public override Descuento Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM descuento WHERE de_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Descuento(ReadInt(0), ReadFloat(1), ReadString(2));
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

        public override List<Descuento> Todos()
        {
            List<Descuento> lista = new List<Descuento>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM descuento";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Descuento descuento = new Descuento(ReadInt(0), ReadFloat(1), ReadString(2));

                    lista.Add(descuento);
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

                string Comando = "UPDATE descuento SET de_porcentaje = @porcentaje, de_descripcion = @descripcion WHERE de_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("porcentaje", Porcentaje);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

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

                string Commando = "DELETE FROM descuento WHERE de_codigo = @codigo";
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