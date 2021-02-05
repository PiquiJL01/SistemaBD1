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
                Conexion.Open();

                if (CodigoJefe == 0)
                {
                    string Comando = "UPDATE empleado SET em_rif = @rif, em_cedula = @cedula, em_1er_nombre = @nombre1, em_2do_nombre = @nombre2, " +
                    "em_1er_apellido = @apellido1, em_2do_apellido = @apellido2, tienda_ti_codigo = @tienda, " +
                    "departamento_de_codigo = @departamento, lugar_lu_codigo = @direccion, " +
                    "correo_electronico_ce_codigo = @correo, em_password  = @password" +
                    "WHERE em_codigo = @codigo";
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
                    string Comando = "UPDATE empleado SET em_rif = @rif, em_cedula = @cedula, em_1er_nombre = @nombre1, em_2do_nombre = @nombre2, " +
                    "em_1er_apellido = @apellido1, em_2do_apellido = @apellido2, tienda_ti_codigo = @tienda, " +
                    "departamento_de_codigo = @departamento, empleado_em_codigo = @jefe, lugar_lu_codigo = @direccion, " +
                    "correo_electronico_ce_codigo = @correo, em_password  = @password" +
                    "WHERE em_codigo = @codigo";
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
                try
                {
                    Conexion.Close();
                }
                finally { }
            }

            foreach (int codigo in codigos)
            {
                beneficios.Add(new Beneficio(codigo));
            }

            return beneficios;
        }

        public List<Horario> Horarios()
        {
            List<Horario> horarios = new List<Horario>();
            List<int> codigos = new List<int>();

            try
            {
                Conexion.Open();

                string Command = "SELECT horario_ho_codigo FROM em_ho WHERE empleado_em_codigo = @codigo";
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
                try
                {
                    Conexion.Close();
                }
                finally { }
            }

            foreach (int codigo in codigos)
            {
                horarios.Add(new Horario(codigo));
            }

            return horarios;
        }
        #endregion
    }
}