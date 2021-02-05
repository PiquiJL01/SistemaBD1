using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Telefono : ConexionBD<Telefono, Dictionary<NumeroTelefono, int>>
    {
        #region Atributos
        public Dictionary<NumeroTelefono, int> Numero = null;
        public string Tipo { get; set; }
        public string RifCliente { get; set; }
        public int CodigoPersonaContacto { get; set; }
        public string RifProveedor { get; set; }
        public int CodigoEmpleado { get; set; }
        #endregion

        #region Declaraciones
        public Telefono(int codigoPais, int codigoArea, int numero, String tipo,
            Cliente cliente)
        {
            Numero = new Dictionary<NumeroTelefono, int>
            {
                { NumeroTelefono.Pais, codigoPais },
                { NumeroTelefono.Area, codigoArea },
                { NumeroTelefono.Numero, numero }
            };

            Tipo = tipo;
            RifCliente = cliente.RIF;
            CodigoPersonaContacto = 0;
            RifProveedor = null;
            CodigoEmpleado = 0;
        }

        public Telefono(int codigoPais, int codigoArea, int numero, String tipo,
            PersonaContacto personaContacto)
        {
            Numero = new Dictionary<NumeroTelefono, int>
            {
                { NumeroTelefono.Pais, codigoPais },
                { NumeroTelefono.Area, codigoArea },
                { NumeroTelefono.Numero, numero }
            };

            Tipo = tipo;
            RifCliente = null;
            CodigoPersonaContacto = personaContacto.Codigo;
            RifProveedor = null;
            CodigoEmpleado = 0;
        }

        public Telefono(int codigoPais, int codigoArea, int numero, String tipo,
            Proveedor proveedor)
        {
            Numero = new Dictionary<NumeroTelefono, int>
            {
                { NumeroTelefono.Pais, codigoPais },
                { NumeroTelefono.Area, codigoArea },
                { NumeroTelefono.Numero, numero }
            };

            Tipo = tipo;
            RifCliente = null;
            CodigoPersonaContacto = 0;
            RifProveedor = proveedor.RIF;
            CodigoEmpleado = 0;
        }

        public Telefono(int codigoPais, int codigoArea, int numero, String tipo,
            Empleado empleado)
        {
            Numero = new Dictionary<NumeroTelefono, int>
            {
                { NumeroTelefono.Pais, codigoPais },
                { NumeroTelefono.Area, codigoArea },
                { NumeroTelefono.Numero, numero }
            };

            Tipo = tipo;
            RifCliente = null;
            CodigoPersonaContacto = 0;
            RifProveedor = null;
            CodigoEmpleado = 0;
        }

        public Telefono(int codigoPais, int codigoArea, int numero)
        {
            Dictionary<NumeroTelefono, int> diccionario = new Dictionary<NumeroTelefono, int>
            {
                { NumeroTelefono.Pais, codigoPais },
                { NumeroTelefono.Area, codigoArea },
                { NumeroTelefono.Numero, numero }
            };
            Telefono telefono = Leer(diccionario);
            if (!(telefono == null))
            {
                Numero = telefono.Numero;
                Tipo = telefono.Tipo;
                RifCliente = telefono.RifCliente;
                CodigoPersonaContacto = telefono.CodigoPersonaContacto;
                RifProveedor = telefono.RifProveedor;
                CodigoEmpleado = telefono.CodigoEmpleado;
            }
        }

        private Telefono(int codigoPais, int codigoArea, int numero, string tipo, int codigoPersonaContacto,
            int codigoEmpleado, string rifCliente, string rifProveedor)
        {
            Numero = new Dictionary<NumeroTelefono, int>
            {
                { NumeroTelefono.Pais, codigoPais },
                { NumeroTelefono.Area, codigoArea },
                { NumeroTelefono.Numero, numero }
            };
            Tipo = tipo;
            RifCliente = rifCliente;
            CodigoPersonaContacto = codigoPersonaContacto;
            RifProveedor = rifProveedor;
            CodigoEmpleado = codigoEmpleado;
        }

        public Telefono()
        {

        }

        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                //Crea el Script en base al atributo que no sea nulo
                if (!(RifCliente == null))
                {
                    string Comando = "INSERT INTO telefono (te_codigo_pais, te_codigo_area, te_numero, te_tipo, cliente_cl_rif) " +
                        "VALUES (@pais, @area, @numero, @tipo, @cliente)";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("pais", Numero[NumeroTelefono.Pais]);
                    Script.Parameters.AddWithValue("area", Numero[NumeroTelefono.Area]);
                    Script.Parameters.AddWithValue("numero", Numero[NumeroTelefono.Numero]);
                    Script.Parameters.AddWithValue("tipo", Tipo);
                    Script.Parameters.AddWithValue("cliente", RifCliente);
                }
                else if (!(CodigoPersonaContacto == 0))
                {
                    string Comando = "INSERT INTO telefono (te_codigo_pais, te_codigo_area, te_numero, te_tipo, persona_contacto_pc_codigo) " +
                    "VALUES (@pais, @area, @numero, @tipo, @persona)";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("pais", Numero[NumeroTelefono.Pais]);
                    Script.Parameters.AddWithValue("area", Numero[NumeroTelefono.Area]);
                    Script.Parameters.AddWithValue("numero", Numero[NumeroTelefono.Numero]);
                    Script.Parameters.AddWithValue("tipo", Tipo);
                    Script.Parameters.AddWithValue("persona", CodigoPersonaContacto);
                }
                else if (!(RifProveedor == null))
                {
                    string Comando = "INSERT INTO telefono (te_codigo_pais, te_codigo_area, te_numero, te_tipo, proveedor_pr_rif) " +
                        "VALUES (@pais, @area, @numero, @tipo, @proveedor)";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("pais", Numero[NumeroTelefono.Pais]);
                    Script.Parameters.AddWithValue("area", Numero[NumeroTelefono.Area]);
                    Script.Parameters.AddWithValue("numero", Numero[NumeroTelefono.Numero]);
                    Script.Parameters.AddWithValue("tipo", Tipo);
                    Script.Parameters.AddWithValue("proveedor", RifProveedor);
                }
                else if (!(CodigoEmpleado == 0))
                {
                    string Comando = "INSERT INTO telefono (te_codigo_pais, te_codigo_area, te_numero, te_tipo, empleado_em_codigo) " +
                        "VALUES (@pais, @area, @numero, @tipo, @proveedor)";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("pais", Numero[NumeroTelefono.Pais]);
                    Script.Parameters.AddWithValue("area", Numero[NumeroTelefono.Area]);
                    Script.Parameters.AddWithValue("numero", Numero[NumeroTelefono.Numero]);
                    Script.Parameters.AddWithValue("tipo", Tipo);
                    Script.Parameters.AddWithValue("proveedor", RifProveedor);
                }
                else
                {
                    throw new Exception("telefono no valido");
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

        public override Telefono Leer(Dictionary<NumeroTelefono, int> numero)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM telefono WHERE ((te_codigo_pais = @pais) AND " +
                    "(te_codigo_area = @area) AND (te_numero = @numero))";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("pais", Numero[NumeroTelefono.Pais]);
                Script.Parameters.AddWithValue("area", Numero[NumeroTelefono.Area]);
                Script.Parameters.AddWithValue("numero", Numero[NumeroTelefono.Numero]);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Telefono(ReadInt(0), ReadInt(1), ReadInt(2), ReadString(3), ReadInt(4),
                        ReadInt(5), ReadString(6), ReadString(7));
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

        public override List<Telefono> Todos()
        {
            List<Telefono> lista = new List<Telefono>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM telefono";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Telefono telefono = new Telefono(ReadInt(0), ReadInt(1), ReadInt(2),
                        ReadString(3), ReadInt(4), ReadInt(5), ReadString(6), ReadString(7));

                    lista.Add(telefono);
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

        /// <summary>
        /// No implementada
        /// </summary>
        public override void Actualizar()
        {

        }

        public override void Eliminar()
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM telefono WHERE ((te_codigo_pais = @pais) AND " +
                    "(te_codigo_area = @area) AND (te_numero = @numero))";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("pais", Numero[NumeroTelefono.Pais]);
                Script.Parameters.AddWithValue("area", Numero[NumeroTelefono.Area]);
                Script.Parameters.AddWithValue("numero", Numero[NumeroTelefono.Numero]);

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

        #endregion

        #region Busqueda por Clave Foranea
        public List<Telefono> Leer(Cliente cliente)
        {
            List<Telefono> lista = new List<Telefono>();
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM telefono WHERE cliente_cl_rif = @rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", cliente.RIF);
                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Telefono telefono = new Telefono(ReadInt(0), ReadInt(1), ReadInt(2), ReadString(3), ReadInt(4),
                        ReadInt(5), ReadString(6), ReadString(7));
                    lista.Add(telefono);
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

        public List<Telefono> Leer(Empleado empleado)
        {
            List<Telefono> listaTelefono = new List<Telefono>();
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM telefono WHERE empleado_em_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", empleado.Codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    Telefono telefono = new Telefono(ReadInt(0), ReadInt(1), ReadInt(2), ReadString(3), ReadInt(4),
                        ReadInt(5), ReadString(6), ReadString(7));
                    listaTelefono.Add(telefono);
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
            return listaTelefono ;
        }

        public List<Telefono> Leer(PersonaContacto personaContacto)
        {
            List<Telefono> listaTelefono = new List<Telefono>();
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM telefono WHERE persona_contacto_pc_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", personaContacto.Codigo);
                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Telefono telefono = new Telefono(ReadInt(0), ReadInt(1), ReadInt(2), ReadString(3), ReadInt(4),
                        ReadInt(5), ReadString(6), ReadString(7));
                    listaTelefono.Add(telefono);
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
            return listaTelefono;
        }

        public List<Telefono> Leer(Proveedor proveedor)
        {
            List<Telefono> lista = new List<Telefono>();
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM telefono WHERE proveedor_pr_rif = @rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", proveedor.RIF);
                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Telefono telefono = new Telefono(ReadInt(0), ReadInt(1), ReadInt(2), ReadString(3), ReadInt(4),
                        ReadInt(5), ReadString(6), ReadString(7));

                    lista.Add(telefono);
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
        #endregion
    }
}