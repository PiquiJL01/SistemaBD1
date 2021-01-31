using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class PersonaContacto : ConexionBD<PersonaContacto, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Cedula { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string RifClienteJuridico { get; set; }
        public string RifProveedor { get; set; }
        #endregion

        #region Declaraciones
        public PersonaContacto(string cedula, string nombre1, string nombre2,
            string apellido1, string apellido2, Juridico juridico)
        {
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            RifClienteJuridico = juridico.RIF;
            RifProveedor = null;
        }

        public PersonaContacto(string cedula, string nombre1, string nombre2,
            string apellido1, string apellido2, Proveedor proveedor)
        {
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            RifClienteJuridico = null;
            RifProveedor = proveedor.RIF;
        }

        public PersonaContacto(int codigo = 0)
        {
            if (!(codigo == 0))
            {
                PersonaContacto personaContacto = Leer(codigo);
                if (!(personaContacto == null))
                {
                    Codigo = personaContacto.Codigo;
                    Cedula = personaContacto.Cedula;
                    Nombre1 = personaContacto.Nombre1;
                    Nombre2 = personaContacto.Nombre2;
                    Apellido1 = personaContacto.Apellido1;
                    Apellido2 = personaContacto.Apellido2;
                    RifClienteJuridico = personaContacto.RifClienteJuridico;
                    RifProveedor = personaContacto.RifProveedor;
                }
            }
        }

        public PersonaContacto(Proveedor proveedor)
        {
            if (!(proveedor.RIF == null))
            {
                try
                {
                    Conexion.Open();

                    string Comando = "SELECT * FROM persona_contacto WHERE proveedor_pr_rif = @rif";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("rif", proveedor.RIF);
                    Reader = Script.ExecuteReader();

                    if (Reader.Read())
                    {
                        Codigo = ReadInt(0);
                        Cedula = ReadString(1);
                        Nombre1 = ReadString(2);
                        Nombre2 = ReadString(3);
                        Apellido1 = ReadString(4);
                        Apellido2 = ReadString(5);
                        RifClienteJuridico = ReadString(6);
                        RifProveedor = ReadString(7);
                    }
                }
                finally
                {
                    Conexion.Close();
                }
            }
        }

        public PersonaContacto(Juridico juridico)
        {
            if (!(juridico.RIF == null))
            {
                try
                {
                    Conexion.Open();

                    string Comando = "SELECT * FROM persona_contacto WHERE juridico_cl_rif = @rif";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("rif", juridico.RIF);
                    Reader = Script.ExecuteReader();

                    if (Reader.Read())
                    {
                        Codigo = ReadInt(0);
                        Cedula = ReadString(1);
                        Nombre1 = ReadString(2);
                        Nombre2 = ReadString(3);
                        Apellido1 = ReadString(4);
                        Apellido2 = ReadString(5);
                        RifClienteJuridico = ReadString(6);
                        RifProveedor = ReadString(7);
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
            }
        }

        private PersonaContacto(int codigo, string cedula, string nombre1, string nombre2,
            string apellido1, string apellido2, string rifjuridico, string rifProveedor)
        {
            Codigo = codigo;
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            RifClienteJuridico = rifjuridico;
            RifProveedor = rifProveedor;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                if (RifClienteJuridico == null)
                {
                    string Comando = "INSERT INTO persona_contacto (pc_cedula, pc_1er_nombre, pc_2do_nombre, " +
                    "pc_1er_apellido, pc_2do_apellido, proveedor_pr_rif) " +
                    "VALUES (@cedula, @nombre1, @nombre2, @apellido1, @apellido2, @proveedor) " +
                    "RETURNING pc_codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("cedula", Cedula);
                    Script.Parameters.AddWithValue("nombre1", Nombre1);
                    Script.Parameters.AddWithValue("nombre2", Nombre2);
                    Script.Parameters.AddWithValue("apellido1", Apellido1);
                    Script.Parameters.AddWithValue("apellido2", Apellido2);
                    Script.Parameters.AddWithValue("proveedor", RifProveedor);
                }
                else
                {
                    string Comando = "INSERT INTO persona_contacto (pc_cedula, pc_1er_nombre, pc_2do_nombre, " +
                    "pc_1er_apellido, pc_2do_apellido, juridico_cl_rif) " +
                    "VALUES (@cedula, @nombre1, @nombre2, @apellido1, @apellido2, @juridico) " +
                    "RETURNING pc_codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("cedula", Cedula);
                    Script.Parameters.AddWithValue("nombre1", Nombre1);
                    Script.Parameters.AddWithValue("nombre2", Nombre2);
                    Script.Parameters.AddWithValue("apellido1", Apellido1);
                    Script.Parameters.AddWithValue("apellido2", Apellido2);
                    Script.Parameters.AddWithValue("juridico", RifClienteJuridico);
                }

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    Codigo = ReadInt(0);
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
        }

        public override PersonaContacto Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM persona_contacto WHERE pc_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new PersonaContacto(ReadInt(0), ReadString(1), ReadString(2), ReadString(3),
                        ReadString(4), ReadString(5), ReadString(6), ReadString(7));
                }

                Conexion.Close();
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

        public override List<PersonaContacto> Todos()
        {
            List<PersonaContacto> lista = new List<PersonaContacto>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM perona_contacto";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    PersonaContacto persona = new PersonaContacto(ReadInt(0), ReadString(1), ReadString(2), ReadString(3),
                        ReadString(4), ReadString(5), ReadString(6), ReadString(7));

                    lista.Add(persona);
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

                if (RifClienteJuridico == null)
                {
                    string Comando = "UPDATE persona_contacto SET pc_cedula = @cedula, pc_1er_nombre = @nombre1, " +
                        "pc_2do_nombre = @nombre2, pc_1er_apellido = @apellido1, pc_2do_apellido = @apellido2, " +
                        "proveedor_pr_rif = @proveedor WHERE pc_codigo = @codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("codigo", Codigo);
                    Script.Parameters.AddWithValue("cedula", Cedula);
                    Script.Parameters.AddWithValue("nombre1", Nombre1);
                    Script.Parameters.AddWithValue("nombre2", Nombre2);
                    Script.Parameters.AddWithValue("apellido1", Apellido1);
                    Script.Parameters.AddWithValue("apellido2", Apellido2);
                    Script.Parameters.AddWithValue("proveedor", RifProveedor);
                }
                else
                {
                    string Comando = "UPDATE persona_contacto SET pc_cedula = @cedula, pc_1er_nombre = @nombre1, " +
                        "pc_2do_nombre = @nombre2, pc_1er_apellido = @apellido1, pc_2do_apellido = @apellido2, " +
                        "juridico_cl_rif = @juridico WHERE pc_codigo = @codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("codigo", Codigo);
                    Script.Parameters.AddWithValue("cedula", Cedula);
                    Script.Parameters.AddWithValue("nombre1", Nombre1);
                    Script.Parameters.AddWithValue("nombre2", Nombre2);
                    Script.Parameters.AddWithValue("apellido1", Apellido1);
                    Script.Parameters.AddWithValue("apellido2", Apellido2);
                    Script.Parameters.AddWithValue("juridico", RifClienteJuridico);
                }

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
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

                string Commando = "DELETE FROM persona_contacto WHERE pc_codigo = @codigo";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
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
        #endregion

        #region Otros Metodos
        #endregion
    }
}