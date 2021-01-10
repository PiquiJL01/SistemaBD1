using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Cheque : MetodoDePago
    {
        #region Atributos
        public string Numero { get; set; }
        #endregion

        #region Declaraciones
        public Cheque(string nombre, string descripcion, DateTime fecha, string numero)
            : base(nombre, descripcion, fecha)
        {
            Numero = numero;
        }

        private Cheque(int codigo, string numero) : base(codigo)
        {
            Numero = numero;
        }

        public Cheque(int codigo)
        {
            Cheque cheque = LeerCheque(codigo);
            if (!(cheque == null))
            {
                Codigo = cheque.Codigo;
                Nombre = cheque.Nombre;
                Descripcion = cheque.Descripcion;
                Fecha = cheque.Fecha;
                Numero = cheque.Numero;
            }
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                base.Insertar();

                Conexion.Open();

                string Comando = "INSERT INTO cheque (mp_codigo, ch_número) " +
                    "VALUES (@codigo, @numero)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("numero", Numero);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }

        public Cheque LeerCheque(int codigo)
        {
            int clave = 0;
            string numero = null;
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM cheque WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    clave = ReadInt(0);
                    numero = ReadString(1);
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
            Cheque cheque= new Cheque(clave, numero);
            return cheque;
        }

        public List<Cheque> TodosCheques()
        {
            List<Cheque> lista = new List<Cheque>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM cheque";
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
                    lista.Add(new Cheque(clave));
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
                base.Actualizar();

                Conexion.Open();
                string Comando = "UPDATE cheque SET ch_numero = @numero WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("numero", Numero);

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

                string Commando = "DELETE FROM cheque WHERE mp_codigo = @codigo";
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