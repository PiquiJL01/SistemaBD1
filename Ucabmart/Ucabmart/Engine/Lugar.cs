using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Lugar : ConexionBD<Lugar, int>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int CodigoUbicacion { get; set; }


        #region Declaraciones
        public Lugar(int codigo, string nombre, TipoLugar tipo, string descripcion, Lugar ubicacion = null)
        {
            Codigo = codigo;
            Nombre = nombre;
            switch (tipo)
            {
                case TipoLugar.Direccion:
                    Tipo = "Direccion";
                    break;
                case TipoLugar.Estado:  
                    Tipo = "Estado";
                    break;
                case TipoLugar.Municipio:
                    Tipo = "Municipio";
                    break;
                case TipoLugar.Pais:
                    Tipo = "Pais";
                    break;
                case TipoLugar.Parroquia:
                    Tipo = "Parroquia";
                    break;
                default:
                    Tipo = null;
                    break;
            }
            Descripcion = descripcion;
            if (ubicacion == null)
            {
                CodigoUbicacion = 0;
            }
            else
            {
                CodigoUbicacion = ubicacion.Codigo;
            }
        }

        public Lugar(string nombre, TipoLugar tipo, string descripcion, Lugar ubicacion = null)
        {
            Nombre = nombre;
            switch (tipo)
            {
                case TipoLugar.Direccion:
                    Tipo = "Direccion";
                    break;
                case TipoLugar.Estado:
                    Tipo = "Estado";
                    break;
                case TipoLugar.Municipio:
                    Tipo = "Municipio";
                    break;
                case TipoLugar.Pais:
                    Tipo = "Pais";
                    break;
                case TipoLugar.Parroquia:
                    Tipo = "Parroquia";
                    break;
                default:
                    Tipo = null;
                    break;
            }
            Descripcion = descripcion;
            if (ubicacion == null)
            {
                CodigoUbicacion = 0;
            }
            else
            {
                CodigoUbicacion = ubicacion.Codigo;
            }
        }

        public Lugar(int codigo)
        {
            Lugar lugar = Leer(codigo);
            if (!(lugar == null))
            {
                Codigo = lugar.Codigo;
                Nombre = lugar.Nombre;
                Tipo = lugar.Tipo;
                Descripcion = lugar.Descripcion;
                CodigoUbicacion = lugar.CodigoUbicacion;
            }
        }

        private Lugar(int codigo, string nombre, string tipo, string descripcion, int ubicacion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Tipo = tipo;
            Descripcion = descripcion;
            CodigoUbicacion = ubicacion;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();
                string Comando;
                if (CodigoUbicacion == 0)
                {
                    Comando = "INSERT INTO lugar (lu_nombre, lu_tipo, lu_descripcion) VALUES (@nombre, @tipo, @descripcion) RETURNING lu_codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("nombre", Nombre);
                    Script.Parameters.AddWithValue("tipo", Tipo);
                    Script.Parameters.AddWithValue("descripcion", Descripcion);
                }
                else
                {
                    string Command = "INSERT INTO lugar (lu_nombre, lu_tipo, lu_descripcion, lugar_lu_codigo) " +
                        "VALUES (@nombre, @tipo, @descripcion, @lugar) returning lu_codigo";
                    Script = new NpgsqlCommand(Command, Conexion);

                    Script.Parameters.AddWithValue("nombre", Nombre);
                    Script.Parameters.AddWithValue("tipo", Tipo);
                    Script.Parameters.AddWithValue("descripcion", Descripcion);
                    Script.Parameters.AddWithValue("lugar", CodigoUbicacion);
                }

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

        public override Lugar Leer(int codigo)
        {
            Lugar lugar = null;

            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM lugar WHERE lu_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    lugar = new Lugar(ReadInt(0), ReadString(1), ReadString(2), ReadString(3), ReadInt(4));
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

            return lugar;
        }

        public override List<Lugar> Todos()
        {
            List<Lugar> lista = new List<Lugar>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM lugar";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Lugar lugar = new Lugar(ReadInt(0), ReadString(1), ReadString(2), ReadString(3), ReadInt(4));

                    lista.Add(lugar);
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

                if (CodigoUbicacion == 0)
                {
                    string Comando = "UPDATE lugar SET lu_nombre = @nombre, lu_tipo = @tipo, lu_descripcion = @descripcion WHERE lu_codigo = @codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("codigo", Codigo);
                    Script.Parameters.AddWithValue("nombre", Nombre);
                    Script.Parameters.AddWithValue("tipo", Tipo);
                    Script.Parameters.AddWithValue("descripcion", Descripcion);
                }
                else
                {
                    string Command = "UPDATE lugar SET lu_nombre = @nombre, lu_tipo = @tipo, lu_descripcion = @descripcion, lugar_lu_codigo = @lugar " +
                        "WHERE lu_codigo = @ codigo";
                    Script = new NpgsqlCommand(Command, Conexion);

                    Script.Parameters.AddWithValue("codigo", Codigo);
                    Script.Parameters.AddWithValue("nombre", Nombre);
                    Script.Parameters.AddWithValue("tipo", Tipo);
                    Script.Parameters.AddWithValue("descripcion", Descripcion);
                    Script.Parameters.AddWithValue("lugar", CodigoUbicacion);
                }

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

                string Commando = "DELETE FROM lugar WHERE lu_codigo = @codigo";
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