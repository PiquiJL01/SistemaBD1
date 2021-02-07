using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Tienda : ConexionBD<Tienda, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CodigoDireccion { get; set; }
        #endregion

        #region Declaraciones
        public Tienda(string nombre, string descripcion, Lugar direccion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CodigoDireccion = direccion.Codigo;
        }

        public Tienda(int codigo)
        {
            Tienda tienda = Leer(codigo);
            if (!(tienda == null))
            {
                Codigo = tienda.Codigo;
                Nombre = tienda.Nombre;
                Descripcion = tienda.Descripcion;
                CodigoDireccion = tienda.CodigoDireccion;
            }
        }

        private Tienda(int codigo, string nombre, string descripcion, int direccon)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            CodigoDireccion = direccon;
        }

        public Tienda()
        {
        }

        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO tienda (ti_nombre, ti_descripcion, lugar_lu_codigo) " +
                    "VALUES (@nombre, @descripcion, @direccion) RETURNING ti_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);
                Script.Parameters.AddWithValue("direccion", CodigoDireccion);

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

        public override Tienda Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM tienda WHERE ti_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Tienda(ReadInt(0), ReadString(1), ReadString(2), ReadInt(3));
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                Conexion.Close();
            }

            return null;
        }

        public override List<Tienda> Todos()
        {
            List<Tienda> lista = new List<Tienda>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM tienda";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Tienda tienda = new Tienda(ReadInt(0), ReadString(1), ReadString(2), ReadInt(3));

                    lista.Add(tienda);
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

                string Comando = "UPDATE tienda SET ti_nombre = qnombre, ti_descripcion = @descripcion, " +
                    "lugar_lu_codigo = @direccion WHERE ti_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);
                Script.Parameters.AddWithValue("direccion", CodigoDireccion);

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

                string Commando = "DELETE FROM tienda WHERE ti_codigo = @codigo";
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

        #region Otros Metodos
        public int Get_CodTienda(String Name)
        {
            List<Tienda> tiendas = this.Todos();

            foreach (Tienda tienda in tiendas)
            {
                if (tienda.Nombre == Name)
                {
                    return tienda.Codigo;
                }
            }
            return -1;
        }
        #endregion
    }
}