using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Cliente : ConexionBD<Cliente, string>
    {
        #region Atributos
        public string RIF { get; set; }
        public string Password { get; set; }
        public int CodigoCorreoElectronico { get; set; }
        public int CodigoTienda { get; set; }
        #endregion

        #region Declaraciones
        public Cliente(string rif, string password, CorreoElectronico correo, Tienda tienda = null)
        {
            RIF = rif;
            Password = password;
            CodigoCorreoElectronico = correo.Codigo;
            if (tienda == null)
            {
                CodigoTienda = 0;
            }
            else
            {
                CodigoTienda = tienda.Codigo;
            }
        }

        public Cliente()
        {

        }

        private Cliente(string rif, string password, int correo, int tienda)
        {
            RIF = rif;
            Password = password;
            CodigoCorreoElectronico = correo;
            CodigoTienda = tienda;
        }

        public Cliente(string rif)
        {
            Cliente cliente = Leer(rif);
            if (!(cliente == null))
            {
                RIF = cliente.RIF;
                Password = cliente.Password;
                CodigoTienda = cliente.CodigoTienda;
                CodigoCorreoElectronico = cliente.CodigoCorreoElectronico;
            }
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                if (CodigoTienda == 0)
                {
                    string Comando = "INSERT INTO cliente (cl_rif, correo_electronico_ce_codigo, cl_password) " +
                    "VALUES (@rif, @correo, @password)";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("rif", RIF);
                    Script.Parameters.AddWithValue("correo", CodigoCorreoElectronico);
                    Script.Parameters.AddWithValue("password", Password);
                }
                else
                {
                    string Comando = "INSERT INTO cliente (cl_rif, tienda_ti_codigo, correo_electronico_ce_codigo, cl_password) " +
                    "VALUES (@rif, @tienda, @correo, @password)";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("rif", RIF);
                    Script.Parameters.AddWithValue("tienda", CodigoTienda);
                    Script.Parameters.AddWithValue("correo", CodigoCorreoElectronico);
                    Script.Parameters.AddWithValue("password", Password);
                }

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }

        public override Cliente Leer(string rif)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM cliente WHERE cl_rif=@rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", rif);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Cliente(ReadString(0), ReadString(3), ReadInt(2), ReadInt(1));
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

        public override List<Cliente> Todos()
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM cliente";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Cliente cliente= new Cliente(ReadString(0), ReadString(3), ReadInt(1), ReadInt(2));

                    lista.Add(cliente);
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

                if (CodigoTienda == 0)
                {
                    string Comando = "UPDATE cliente SET correo_electronico_ce_codigo = @correo WHERE cl_rif = @rif";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("rif", RIF);
                    Script.Parameters.AddWithValue("correo", CodigoCorreoElectronico);
                }
                else
                {
                    string Comando = "UPDATE cliente SET correo_electronico_ce_codigo = @correo, tienda_ti_codigo = @tienda WHERE cl_rif = @rif";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("rif", RIF);
                    Script.Parameters.AddWithValue("correo", CodigoCorreoElectronico);
                    Script.Parameters.AddWithValue("tienda", CodigoTienda);
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

                string Commando = "DELETE FROM cliente WHERE cl_rif = @rif";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("rif", RIF);

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