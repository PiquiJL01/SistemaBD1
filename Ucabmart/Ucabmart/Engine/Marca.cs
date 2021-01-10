using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Marca : ConexionBD<Marca, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool EsPropia { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Declaraciones
        public Marca(string nombre, bool esPropia, string descripcion)
        {
            Nombre = nombre;
            EsPropia = esPropia;
            Descripcion = descripcion;
        }

        public Marca(int codigo)
        {
            Marca marca = Leer(codigo);
            if (!(marca == null))
            {
                Codigo = marca.Codigo;
                Nombre = marca.Nombre;
                EsPropia = marca.EsPropia;
                Descripcion = marca.Descripcion;
            }
        }

        private Marca(int codigo, string nombre, bool esPropia, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            EsPropia = esPropia;
            Descripcion = descripcion;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO marca (ma_nombre, ma_propia, ma_descripcion) " +
                    "VALUES (@nombre, @propia, @descripcion) RETURNING ma_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("propia", EsPropia);
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

        public override Marca Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM marca WHERE ma_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Marca(ReadInt(0), ReadString(1), ReadBool(2), ReadString(3));
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

        public override List<Marca> Todos()
        {
            List<Marca> lista = new List<Marca>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM marca";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Marca marca = new Marca(ReadInt(0), ReadString(1), ReadBool(2), ReadString(3));

                    lista.Add(marca);
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

                string Comando = "UPDATE tabla SET ma_nombre = @nombre, ma_propia = @propia, ma_descripcion = @descripcion " +
                    "WHERE ma_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("propia", EsPropia);
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

                string Commando = "DELETE FROM marca WHERE ma_codigo = @codigo";
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