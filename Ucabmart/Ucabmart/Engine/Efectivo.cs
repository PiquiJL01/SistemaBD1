using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Efectivo : MetodoDePago
    {
        #region Atributos
        public string CodigoMoneda { get; set; }
        public float Monto { get; set; }
        #endregion

        #region Declaraciones
        public Efectivo(string nombre, string descripcion, DateTime fecha, Moneda moneda, float monto)
            : base(nombre, descripcion, fecha)
        {
            CodigoMoneda = moneda.Codigo;
            Monto = monto;
        }

        private Efectivo(int codigo, string moneda, float monto) : base(codigo)
        {
            CodigoMoneda = moneda;
            Monto = monto;
        }

        public Efectivo(int codigo)
        {
            Efectivo efectivo = LeerEfectivo(codigo);
            if (!(efectivo == null))
            {
                Codigo = efectivo.Codigo;
                Nombre = efectivo.Nombre;
                Descripcion = efectivo.Descripcion;
                Fecha = efectivo.Fecha;
                CodigoMoneda = efectivo.CodigoMoneda;
                Monto = efectivo.Monto;
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

                string Comando = "INSERT INTO efectivo (mp_codigo, moneda_mo_codigo, monto) " +
                    "VALUES (@codigo, @moneda, @monto)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("moneda", CodigoMoneda);
                Script.Parameters.AddWithValue("monto", Monto);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }

        public Efectivo LeerEfectivo(int codigo)
        {
            int clave = 0;
            string moneda = null;
            float monto = 0;
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM efectivo WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    clave = ReadInt(0);
                    moneda = ReadString(1);
                    monto = ReadFloat(2);
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
            Efectivo efectivo = new Efectivo(clave, moneda, monto);
            return efectivo;
        }

        public List<Efectivo> TodosEfectivo()
        {
            List<Efectivo> lista = new List<Efectivo>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM efectivo";
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
                    lista.Add(new Efectivo(clave));
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
                string Comando = "UPDATE efectivo SET moneda_mo_codigo = @moneda, monto = @monto WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("moneda", CodigoMoneda);
                Script.Parameters.AddWithValue("monto", Monto);

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

                string Commando = "DELETE FROM moneda WHERE mp_codigo = @codigo";
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