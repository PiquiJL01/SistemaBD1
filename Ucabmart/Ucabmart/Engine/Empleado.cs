using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Empleado : ConexionBD<Empleado, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Password { get; set; }
        public string RIF { get; set; }
        public string Cedula { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int CodigoDepartamento { get; set; }
        public int CodigoTienda { get; set; }
        public int CodigoJefe { get; set; }
        public int CodigoCorreoElectronico { get; set; }
        public int CodigoDireccion { get; set; }
        #endregion

        #region Declaraciones
        public Empleado(string password, string rif, string cedula, string nombre1, string nombre2, string apellido1, string apellido2,
            Departamento departamento, Tienda tienda, Lugar direccion, CorreoElectronico correo, Empleado jefe )
        {
            Password = password;
            Cedula = cedula;
            RIF = rif;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            CodigoDepartamento = departamento.Codigo;
            CodigoTienda = tienda.Codigo;
            if (jefe == null)
            {
                CodigoJefe = 0;
            }
            else
            {
                CodigoJefe = jefe.Codigo;
            }
            CodigoDireccion = direccion.Codigo;
            CodigoCorreoElectronico = correo.Codigo;
        }

        public Empleado(int codigo)
        {
            Empleado empleado = Leer(codigo);
            if (!(empleado == null))
            {
                Codigo = empleado.Codigo;
                Password = empleado.Password;
                RIF = empleado.RIF;
                Cedula = empleado.Cedula;
                Nombre1 = empleado.Nombre1;
                Nombre2 = empleado.Nombre2;
                Apellido1 = empleado.Apellido1;
                Apellido2 = empleado.Apellido2;
                CodigoDepartamento = empleado.CodigoDepartamento;
                CodigoTienda = empleado.CodigoTienda;
                CodigoJefe = empleado.CodigoJefe;
                CodigoDireccion = empleado.CodigoDireccion;
                CodigoCorreoElectronico = empleado.CodigoCorreoElectronico;
            }
        }

        public Empleado(string rif)
        {
            Empleado empleado = Leer(rif);
            if (!(empleado == null))
            {
                Codigo = empleado.Codigo;
                Password = empleado.Password;
                RIF = empleado.RIF;
                Cedula = empleado.Cedula;
                Nombre1 = empleado.Nombre1;
                Nombre2 = empleado.Nombre2;
                Apellido1 = empleado.Apellido1;
                Apellido2 = empleado.Apellido2;
                CodigoDepartamento = empleado.CodigoDepartamento;
                CodigoTienda = empleado.CodigoTienda;
                CodigoJefe = empleado.CodigoJefe;
                CodigoDireccion = empleado.CodigoDireccion;
                CodigoCorreoElectronico = empleado.CodigoCorreoElectronico;
            }
        }


        private Empleado(int codigo, string rif, string cedula, string nombre1, string nombre2, string apellido1, string apellido2,
            int tienda, int departamento, int jefe , int direccion , int correo, string password )
        {
            Codigo = codigo;
            Cedula = cedula;
            Password = password;
            RIF = rif;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            CodigoDepartamento = departamento;
            CodigoTienda = tienda;
            CodigoJefe = jefe;
            CodigoDireccion = direccion;
            CodigoCorreoElectronico = correo;
        }

        public Empleado()
        {

        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                if (CodigoJefe == 0)
                {
                    string Comando = "INSERT INTO empleado (em_rif, em_cedula, em_1er_nombre, em_2do_nombre, em_1er_apellido, em_2do_apellido, " +
                    "tienda_ti_codigo, departamento_de_codigo, lugar_lu_codigo, correo_electronico_ce_codigo, em_password) " +
                    "VALUES (@rif, @cedula, @nombre1, @nombre2, @apellido1, @apellido2, @tienda, @departamento, @direccion, " +
                    "@correo, @password) " +
                    "RETURNING em_codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("rif", RIF);
                    Script.Parameters.AddWithValue("cedula", Cedula);
                    Script.Parameters.AddWithValue("nombre1", Nombre1);
                    Script.Parameters.AddWithValue("nombre2", Nombre2);
                    Script.Parameters.AddWithValue("apellido1", Apellido1);
                    Script.Parameters.AddWithValue("apellido2", Apellido2);
                    Script.Parameters.AddWithValue("tienda", CodigoTienda);
                    Script.Parameters.AddWithValue("departamento", CodigoDepartamento);
                    Script.Parameters.AddWithValue("direccion", CodigoDireccion);
                    Script.Parameters.AddWithValue("correo", CodigoCorreoElectronico);
                    Script.Parameters.AddWithValue("password", Password);
                }
                else
                {
                    string Comando = "INSERT INTO empleado (em_rif, em_cedula, em_1er_nombre, em_2do_nombre, em_1er_apellido, em_2do_apellido, " +
                    "tienda_ti_codigo, departamento_de_codigo, empleado_em_codigo, lugar_lu_codigo, correo_electronico_ce_codigo, em_password) " +
                    "VALUES (@rif, @cedula, @nombre1, @nombre2, @apellido1, @apellido2, @tienda, @departamento, @jefe, @direccion, " +
                    "@correo, @password) " +
                    "RETURNING em_codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("rif", RIF);
                    Script.Parameters.AddWithValue("cedula", Cedula);
                    Script.Parameters.AddWithValue("nombre1", Nombre1);
                    Script.Parameters.AddWithValue("nombre2", Nombre2);
                    Script.Parameters.AddWithValue("apellido1", Apellido1);
                    Script.Parameters.AddWithValue("apellido2", Apellido2);
                    Script.Parameters.AddWithValue("tienda", CodigoTienda);
                    Script.Parameters.AddWithValue("departamento", CodigoDepartamento);
                    Script.Parameters.AddWithValue("jefe", CodigoJefe);
                    Script.Parameters.AddWithValue("direccion", CodigoDireccion);
                    Script.Parameters.AddWithValue("correo", CodigoCorreoElectronico);
                    Script.Parameters.AddWithValue("password", Password);
                }

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

        public override Empleado Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM empleado WHERE em_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    Empleado empleado = new Empleado(ReadInt(0), ReadString(1), ReadString(2), ReadString(3), ReadString(4), ReadString(5),
                        ReadString(6), ReadInt(7), ReadInt(8), ReadInt(9), ReadInt(10), ReadInt(11), ReadString(12));
                    CerrarConexion();
                    return empleado;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                CerrarConexion();
            }

            return null;
        }

        public Empleado Leer(string rif)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM empleado WHERE em_rif=@rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", rif);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Empleado(ReadInt(0), ReadString(1), ReadString(2), ReadString(3), ReadString(4), ReadString(5),
                        ReadString(6), ReadInt(7), ReadInt(8), ReadInt(9), ReadInt(10), ReadInt(11), ReadString(12));
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

        public override List<Empleado> Todos()
        {
            List<Empleado> lista = new List<Empleado>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM empleado";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Empleado empleado = new Empleado(ReadInt(0), ReadString(1), ReadString(2), ReadString(3), ReadString(4), ReadString(5),
                        ReadString(6), ReadInt(7), ReadInt(8), ReadInt(9), ReadInt(10), ReadInt(11), ReadString(12));

                    lista.Add(empleado);
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
                if (AbrirConexion())
                {
                    if (CodigoJefe == 0)
                    {
                        string Comando = "UPDATE empleado " +
                            "SET em_rif = @rif, em_cedula = @cedula, em_1er_nombre = @nombre1, em_2do_nombre = @nombre2, " +
                                "em_1er_apellido = @apellido1, em_2do_apellido = @apellido2, tienda_ti_codigo = @tienda, " +
                                "departamento_de_codigo = @departamento, lugar_lu_codigo = @direccion, " +
                                "correo_electronico_ce_codigo = @correo, em_password = @password " +
                            "WHERE em_codigo = @codigo";
                        Script = new NpgsqlCommand(Comando, Conexion);

                        Script.Parameters.AddWithValue("codigo", Codigo);
                        Script.Parameters.AddWithValue("rif", RIF);
                        Script.Parameters.AddWithValue("cedula", Cedula);
                        Script.Parameters.AddWithValue("nombre1", Nombre1);
                        Script.Parameters.AddWithValue("nombre2", Nombre2);
                        Script.Parameters.AddWithValue("apellido1", Apellido1);
                        Script.Parameters.AddWithValue("apellido2", Apellido2);
                        Script.Parameters.AddWithValue("tienda", CodigoTienda);
                        Script.Parameters.AddWithValue("departamento", CodigoDepartamento);
                        Script.Parameters.AddWithValue("direccion", CodigoDireccion);
                        Script.Parameters.AddWithValue("correo", CodigoCorreoElectronico);
                        Script.Parameters.AddWithValue("password", Password);
                    }
                    else
                    {
                        string Comando = "UPDATE empleado " +
                            "SET em_rif = @rif, em_cedula = @cedula, em_1er_nombre = @nombre1, em_2do_nombre = @nombre2, " +
                                "em_1er_apellido = @apellido1, em_2do_apellido = @apellido2, tienda_ti_codigo = @tienda, " +
                                "departamento_de_codigo = @departamento, empleado_em_codigo = @jefe, lugar_lu_codigo = @direccion, " +
                                "correo_electronico_ce_codigo = @correo, em_password = @password " +
                            "WHERE em_codigo = @codigo";
                        Script = new NpgsqlCommand(Comando, Conexion);

                        Script.Parameters.AddWithValue("codigo", Codigo);
                        Script.Parameters.AddWithValue("rif", RIF);
                        Script.Parameters.AddWithValue("cedula", Cedula);
                        Script.Parameters.AddWithValue("nombre1", Nombre1);
                        Script.Parameters.AddWithValue("nombre2", Nombre2);
                        Script.Parameters.AddWithValue("apellido1", Apellido1);
                        Script.Parameters.AddWithValue("apellido2", Apellido2);
                        Script.Parameters.AddWithValue("tienda", CodigoTienda);
                        Script.Parameters.AddWithValue("departamento", CodigoDepartamento);
                        Script.Parameters.AddWithValue("jefe", CodigoJefe);
                        Script.Parameters.AddWithValue("direccion", CodigoDireccion);
                        Script.Parameters.AddWithValue("correo", CodigoCorreoElectronico);
                        Script.Parameters.AddWithValue("password", Password);
                    }

                    Script.Prepare();

                    Script.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                CerrarConexion();
            }
            
        }

        public override void Eliminar()
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM empleado WHERE em_codigo = @codigo";
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
        #endregion

        #region Entidades Muchos a Muchos
        public List<Beneficio> Beneficios()
        {
            List<Beneficio> beneficios = new List<Beneficio>();
            List<int> codigos = new List<int>();

            try
            {
                Conexion.Open();

                string Command = "SELECT beneficio_be_codigo FROM em_be WHERE empleado_em_codigo = @codigo";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    codigos.Add(ReadInt(0));
                }
            }
            finally
            {
                CerrarConexion();
            }

            foreach (int codigo in codigos)
            {
                beneficios.Add(new Beneficio(codigo));
            }

            return beneficios;
        }

        public List<Rol> Roles()
        {
            List<Rol> roles = new List<Rol>();
            List<int> codigos = new List<int>();

            try
            {
                Conexion.Open();

                string Command = "SELECT rol_ro_codigo FROM ro_em WHERE empleado_em_codigo = @codigo";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    codigos.Add(ReadInt(0));
                }
            }
            finally
            {
                CerrarConexion();
            }

            foreach (int codigo in codigos)
            {
                roles.Add(new Rol(codigo));
            }

            return roles;
        }

        public List<Permiso> Permisos()
        {
            List<Permiso> permisos = new List<Permiso>();

            //Evalua para todos los roles del empleado
            List<Rol> roles = Roles();
            foreach (Rol rol in roles)
            {
                //Evalua para todos los permisos del rol
                List<Permiso> permisos1 = rol.Permisos();
                foreach (Permiso permiso1 in permisos1)
                {
                    //Evalua si el rol ya estaba en los permisos agregados
                    bool isIn = false;
                    foreach (Permiso permiso in permisos)
                    {
                        if (permiso.Codigo == permiso1.Codigo)
                        {
                            isIn = true;
                            break;
                        }
                    }
                    if (!isIn)
                    {
                        permisos.Add(permiso1);
                    }
                }
            }

            return permisos;
        }

        public List<Horario> Horarios()
        {
            List<Horario> horarios = new List<Horario>();
            List<int> codigos = new List<int>();

            if(AbrirConexion())
            {

                string Command = "SELECT horario_ho_codigo FROM em_ho WHERE empleado_em_codigo = @codigo";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    codigos.Add(ReadInt(0));
                }
            }

            CerrarConexion();

            foreach (int codigo in codigos)
            {
                horarios.Add(new Horario(codigo));
            }

            return horarios;
        }

        public List<int> CodigosHorarios()
        {
            List<int> listaHorario = new List<int>();

            if (AbrirConexion())
            {
                string Comando = "SELECT horario_ho_codigo FROM em_ho WHERE empleado_em_codigo=@codigoEmpleado";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigoEmpleado", Codigo);
                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    listaHorario.Add(ReadInt(0));
                }
            }

            CerrarConexion();

            return listaHorario;
        }

        public List<Cargo> Cargos()
        {
            List<Cargo> cargos = new List<Cargo>();
            List<int> codigos = new List<int>();

            if (AbrirConexion())
            {
                string Command = "SELECT cargo_ca_codigo FROM em_ca WHERE empleado_em_codigo = @codigo";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    codigos.Add(ReadInt(0));
                }
            }

            CerrarConexion();

            foreach (int codigo in codigos)
            {
                cargos.Add(new Cargo(codigo));
            }

            return cargos;
        }

        /// <summary>
        /// Conexion con la BD
        /// </summary>
        /// <remarks>La tupla tiene: el sueldo (float)y las fechas de inicio y fin en ese orden (DateTime, fin puede ser null)</remarks>
        /// <returns>Atributos de los cargos del empleaado, basado en su historico</returns>
        public Dictionary<int, Tuple<float,DateTime, DateTime>> AtributosCargos()
        {
            Dictionary<int, Tuple<float, DateTime, DateTime>> sueldos = new Dictionary<int, Tuple<float, DateTime, DateTime>>();

            if (AbrirConexion())
            {
                string Command = "SELECT cargo_ca_codigo, sueldo FROM em_ca WHERE empleado_em_codigo = @codigo";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Tuple<float, DateTime, DateTime> tuple = new Tuple<float, DateTime, DateTime>(ReadFloat(1), ReadDate(2), ReadDate(3));
                    sueldos.Add(ReadInt(0), tuple);
                }
            }

            CerrarConexion();

            return sueldos;
        }

        public Cargo CargoActual()
        {
            Dictionary<int, Tuple<float, DateTime, DateTime>> valores = AtributosCargos();
            foreach (int codigo in valores.Keys)
            {
                if (valores[codigo].Item3.Year == 0001)
                {
                    return new Cargo(codigo);
                }
            }
            return null;
        }

        public Tuple<float, DateTime, DateTime> AtributosCargoActual()
        {
            return AtributosCargos()[CargoActual().Codigo];
        }

        public float SueldoActual()
        {
            return AtributosCargoActual().Item1;
        }
        #endregion

        #region Otros Metodos
        public List<int> BuscarEnCargo()
        {
            List<int> lista = new List<int>();
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM em_ca WHERE empleado_em_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    lista.Add(ReadInt(1));
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