using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Permiso : ConexionBD<Permiso, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool EstaPermitido { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Declaraciones
        public Permiso(string nombre, string descripcion, bool estaPermitido = true)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            EstaPermitido = estaPermitido;
        }

        public Permiso(int codigo = 0)
        {
            if (!(codigo == 0))
            {
                Permiso permiso = Leer(codigo);
                Codigo = permiso.Codigo;
                Nombre = permiso.Nombre;
                Descripcion = permiso.Descripcion;
                EstaPermitido = permiso.EstaPermitido;
            }
        }

        private Permiso(int codigo, string nombre, bool estaPermitido, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            EstaPermitido = estaPermitido;
            Descripcion = descripcion;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO permiso (pe_nombre, pe_esta_permitido, pe_descripcion) " +
                    "VALUES (@nombre, @permitido, @descripcion) RETURNING codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("permitido", EstaPermitido);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    Codigo = ReadInt(0);
                }

                Conexion.Close();
            }
            finally
            {
                CerrarConexion();
            }
        }

        public override Permiso Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM permiso WHERE pe_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    Permiso permiso = new Permiso(ReadInt(0), ReadString(1),ReadBool(2), ReadString(3));
                    CerrarConexion();
                    return permiso;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                CerrarConexion();
            }

            return null;
        }

        public override List<Permiso> Todos()
        {
            List<Permiso> lista = new List<Permiso>();

            if (AbrirConexion())
            {

                string Command = "SELECT * FROM permiso";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Permiso permiso = new Permiso(ReadInt(0), ReadString(1), ReadBool(2), ReadString(3));

                    lista.Add(permiso);
                }
            }


            CerrarConexion();

            return lista;
        }

        public override void Actualizar()
        {
            try
            {
                Conexion.Open();

                string Comando = "UPDATE permiso SET pe_nombre = @nombre, pe_esta_permitido = @permitido, pe_descripcion = @descripcion " +
                    "WHERE codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("permitido", EstaPermitido);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                CerrarConexion();
            }
        }

        public override void Eliminar()
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM permiso WHERE pe_codigo = @codigo";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                CerrarConexion();
            }
        }
        #endregion
    }
}