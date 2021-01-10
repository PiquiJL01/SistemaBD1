using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Canje : MetodoDePago
    {
        #region Atributos
        #endregion

        #region Declaraciones
        public Canje(string nombre, string descripcion, DateTime fecha) : base(nombre, descripcion, fecha) { }

        public Canje(int codigo) : base(codigo) { } 
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                base.Insertar();

                Conexion.Open();
                
                string Comando = "INSERT INTO canje (mp_codigo) " + 
                    "VALUES (@codigo)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }

        public Canje LeerCanje(int codigo)
        {
            int clave = 0;
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM canje WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    clave = ReadInt(0);
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
            Canje canje = new Canje(clave);
            return canje;
        }

        public List<Canje> TodosCanajes()
        {
            List<Canje> lista = new List<Canje>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM canje";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                List<int> claves = new List<int>();

                while (Reader.Read())
                {
                    claves.Add(ReadInt(0));
                }

                Conexion.Close();

                foreach (int clave in claves)
                {
                    lista.Add(new Canje(clave));
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

        /// <summary>
        /// Funcion no implementada, <c>Canje</c> no tiene atibutos que actualizar
        /// </summary>
        public override void Actualizar()
        {
            /*
            try
            {
                base.Actualizar();

                Conexion.Open();
                string Comando = "UPDATE canje SET  WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

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
            */
        }

        public override void Eliminar()
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM canje WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();

                base.Eliminar();
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