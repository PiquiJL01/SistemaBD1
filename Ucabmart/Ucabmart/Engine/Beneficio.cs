using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Beneficio : ConexionBD<Beneficio, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Declaraciones
        public Beneficio(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        private Beneficio(int codigo, string nombre, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Beneficio(int codigo = 0)
        {
            if (!(codigo == 0))
            {
                Beneficio beneficio = Leer(codigo);
                if (!(beneficio == null))
                {
                    Codigo = beneficio.Codigo;
                    Nombre = beneficio.Nombre;
                    Descripcion = beneficio.Descripcion;
                }
                else
                {
                    Codigo = 0;
                    Nombre = null;
                    Descripcion = null;
                }
            }
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO beneficio (be_nombre, be_descripcion) VALUES (@nombre, @descripcion) RETURNING be_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("nombre", Nombre);
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

        public override Beneficio Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM beneficio WHERE be_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Beneficio(ReadInt(0), ReadString(1), ReadString(2));
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

            return null;
        }

        public override List<Beneficio> Todos()
        {
            List<Beneficio> lista = new List<Beneficio>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM beneficio";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Beneficio beneficio = new Beneficio(ReadInt(0), ReadString(1), ReadString(2));

                    lista.Add(beneficio);
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

                string Comando = "UPDATE beneficio SET be_nombre = @nombre, be_descripcion = @descripcion WHERE be_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
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

                string Commando = "DELETE FROM beneficio WHERE be_codigo = @codigo";
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