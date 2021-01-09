using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Almacen : ConexionBD<Almacen, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public int CodigoTienda { get; set; }
        #endregion

        #region Declaraciones
        public Almacen(int codigo, int tienda)
        {
            Codigo = codigo;
            CodigoTienda = tienda;
        }

        public Almacen(int codigo)
        {
            Almacen almacen = Leer(codigo);
            if (!(almacen == null))
            {
                Codigo = almacen.Codigo;
                CodigoTienda = almacen.CodigoTienda;
            }
            else
            {
                Codigo = 0;
                CodigoTienda = 0;
            }
        }

        public Almacen(Tienda tienda)
        {
            CodigoTienda = tienda.Codigo;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO almacen (tienda_ti_codigo) VALUES (@tienda) RETURNING al_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("tienda", CodigoTienda);

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

        public override Almacen Leer(int codigo)
        {
            Almacen almacen = null;

            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM almacen WHERE al_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    almacen = new Almacen(ReadInt(0), ReadInt(1));
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

            return almacen;
        }

        public override List<Almacen> Todos()
        {
            List<Almacen> lista = new List<Almacen>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM almacen";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Almacen almacen= new Almacen(ReadInt(0), ReadInt(1));

                    lista.Add(almacen);
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

                string Comando = "UPDATE almacen SET tienda_ti_tienda = @tienda WHERE al_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("tienda", CodigoTienda);

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

                string Commando = "DELETE FROM almacen WHERE al_codigo = @codigo";
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