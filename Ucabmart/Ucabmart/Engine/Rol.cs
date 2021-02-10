using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Rol : ConexionBD<Rol, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructores
        public Rol(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Rol(int codigo = 0)
        {
            if (!(codigo == 0))
            {
                Rol rol = Leer(codigo);
                Codigo = rol.Codigo;
                Nombre = rol.Nombre;
                Descripcion = rol.Descripcion;
            }
        }

        public Rol()
        {
        }

        private Rol(int codigo, string nombre, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            if (AbrirConexion())
            { 
                string Comando = "INSERT INTO rol (ro_nombre, ro_descripcion) VALUES (@nombre, @descripcion) RETURNING ro_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    Codigo = ReadInt(0);
                }
            }

            CerrarConexion();
        }

        public override Rol Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM rol WHERE ro_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    Rol rol = new Rol(ReadInt(0), ReadString(1), ReadString(2));
                    CerrarConexion();
                    return rol;
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

        public override List<Rol> Todos()
        {
            List<Rol> lista = new List<Rol>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM rol";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Rol rol = new Rol(ReadInt(0), ReadString(1), ReadString(2)) ;

                    lista.Add(rol);
                }
            }
            finally
            {
                CerrarConexion();
            }

            return lista;
        }

        public override void Actualizar()
        {
            try
            {
                Conexion.Open();

                string Comando = "UPDATE rol SET ro_nombre = @nombre, ro_descripcion = @descripcion WHERE codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
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

                string Commando = "DELETE FROM rol WHERE codigo = @codigo";
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

        #region Muchos a Muchos
        public List<Permiso> Permisos()
        {
            List<Permiso> permisos = new List<Permiso>();
            List<int> codigos = new List<int>();

            if (AbrirConexion())
            {
                string Command = "SELECT permiso_pe_codigo FROM pe_ro WHERE rol_ro_codigo = @codigo";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    codigos.Add(ReadInt(0));
                }
            }

            CerrarConexion();

            foreach (int codigo in codigos)
            {
                permisos.Add(new Permiso(codigo));
            }

            return permisos;
        }

        public string BuscarPermiso(int codigoRol)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT permiso_pe_codigo FROM pe_ro WHERE rol_ro_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigoRol);
                Reader = Script.ExecuteReader();

                string nombre = "";

                while (Reader.Read())
                {
                    Permiso permiso =new Permiso(ReadInt(0));
                    nombre +=  permiso.Nombre + ", \n" ;
                }
                return nombre;
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                CerrarConexion();
            }
        }

        #endregion
    }
}