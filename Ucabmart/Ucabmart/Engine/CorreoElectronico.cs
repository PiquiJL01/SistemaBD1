using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class CorreoElectronico : ConexionBD<CorreoElectronico, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Direccion { get; set; }
        #endregion

        #region Declaraciones
        private CorreoElectronico(int codigo, string direccion)
        {
            Codigo = codigo;
            Direccion = direccion;
        }

        public CorreoElectronico(int codigo)
        {
            CorreoElectronico correo = Leer(codigo);
            if (!(correo == null))
            {
                Codigo = correo.Codigo;
                Direccion = correo.Direccion;
            }
        }

        public CorreoElectronico(string direccion)
        {
            Direccion = direccion;
        }

        public CorreoElectronico()
        {
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO correo_electronico (ce_direccion) VALUES (@direccion) RETURNING ce_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("direccion", Direccion);

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

        public override CorreoElectronico Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM correo_electronico WHERE ce_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new CorreoElectronico(ReadInt(0), ReadString(1));
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

        public override List<CorreoElectronico> Todos()
        {
            List<CorreoElectronico> lista = new List<CorreoElectronico>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM correo_electronico";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    CorreoElectronico correo = new CorreoElectronico(ReadInt(0), ReadString(1));

                    lista.Add(correo);
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

            return lista;
        }

        public override void Actualizar()
        {
            try
            {
                Conexion.Open();

                string Comando = "UPDATE correo_electronico SET ce_direccion = @direccion WHERE ce_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("direccion", Direccion);

                Script.Prepare();

                Script.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                Conexion.Close();
            }
        }

        public override void Eliminar()
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM correo_electronico WHERE ce_codigo = @codigo";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                Conexion.Close();
            }
        }

        public  CorreoElectronico LeerPorNombre(string direccion)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM correo_electronico WHERE ce_direccion=@direccion";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("direccion", direccion);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new CorreoElectronico(ReadInt(0), ReadString(1));
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

        #endregion
    }
}