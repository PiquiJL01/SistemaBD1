using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class MuchosAMuchos
    {
        #region Atributos para establecer la conexion
        private const string ConnectionString = "Host = labs-dbservices01.ucab.edu.ve; User Id = grupo5bd1; Password = 123456789; Database = grupo5db"; //conexion a la bd del proyecto
        private NpgsqlCommand Script;
        public NpgsqlDataReader Reader;
        private NpgsqlConnection Conexion = new NpgsqlConnection(ConnectionString);
        #endregion

        public MuchosAMuchos()
        {
        }

        #region Insertar
        public void Insertar(Empleado empleado, Horario horario)
        {
            if (AbrirConexion())
            {
                string Comando = "INSERT INTO em_ho (empleado_em_codigo, horario_ho_codigo) VALUES (@empleado, @horario)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("empleado", empleado.Codigo);
                Script.Parameters.AddWithValue("horario", horario.Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }

            CerrarConexion();
        }

        public void Insertar(Empleado empleado, Beneficio beneficio, DateTime fecha = new DateTime(), float monto = 0)
        {
            if (fecha.Year == 0001)
            {
                fecha = DateTime.Today;
            }

            if (AbrirConexion())
            {
                string Comando = "INSERT INTO em_be (empleado_em_codigo, beneficio_be_codigo, fecha, monto2) " +
                    "VALUES (@codigo1, @codigo2, @fecha, @monto)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo1", empleado.Codigo);
                Script.Parameters.AddWithValue("codigo2", beneficio.Codigo);
                Script.Parameters.AddWithValue("fecha", fecha);
                Script.Parameters.AddWithValue("monto", monto);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }

            CerrarConexion();
        }

        public void Insertar(Empleado empleado, Cargo cargo, float sueldo = 0, DateTime fechainicio = new DateTime(), DateTime fechaFin = new DateTime())
        {

            try
            {
                if (fechainicio.Year == 0001)
                {
                    fechainicio = DateTime.Today;
                }


                if (AbrirConexion())
                {
                    if (fechaFin.Year == 0001)
                    {
                        string Comando = "INSERT INTO em_ca (empleado_em_codigo, cargo_ca_codigo, sueldo, fecha_inicio) " +
                            "VALUES (@empleado, @cargo, @sueldo, @fechainicio)";
                        Script = new NpgsqlCommand(Comando, Conexion);

                        Script.Parameters.AddWithValue("empleado", empleado.Codigo);
                        Script.Parameters.AddWithValue("cargo", cargo.Codigo);
                        Script.Parameters.AddWithValue("sueldo", sueldo);
                        Script.Parameters.AddWithValue("fechainicio", fechainicio);
                    }
                    else
                    {
                        string Comando = "INSERT INTO em_ca (empleado_em_codigo, cargo_ca_codigo, sueldo, fecha_inicio, fecha_fin) " +
                            "VALUES (@empleado, @cargo, @sueldo, @fechainicio, @fechafin)";
                        Script = new NpgsqlCommand(Comando, Conexion);

                        Script.Parameters.AddWithValue("empleado", empleado.Codigo);
                        Script.Parameters.AddWithValue("cargo", cargo.Codigo);
                        Script.Parameters.AddWithValue("sueldo", sueldo);
                        Script.Parameters.AddWithValue("fechainicio", fechainicio);
                        Script.Parameters.AddWithValue("fechafin", fechaFin);
                    }

                    Script.Prepare();

                    Script.ExecuteNonQuery();
                }
                CerrarConexion();
            }
            catch (Exception ex)
            {

            }


        }

        /* Modelo para Insertar en BD una entidad Muchos a Muchos
        public void Insertar(Tipo1 tipo1, Tipo2 tipo2)
        {
            if(AbrirConexion())
            {
                string Comando = "INSERT INTO tabla (codigo1, codigo2) VALUES (@codigo1, @codigo2)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo1", tipo1.Codigo);
                Script.Parameters.AddWithValue("codigo2", tipo2.Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            CerrarConexion();
        }
        */
        #endregion

        #region Eliminar
        public void Eliminar(Empleado empleado, Horario horario)
        {
            try
            {
                if (AbrirConexion())
                {
                    string Commando = "DELETE FROM em_ho WHERE (empleado_em_codigo = @codigo1) AND (horario_ho_codigo = @codigo2)";
                    Script = new NpgsqlCommand(Commando, Conexion);

                    Script.Parameters.AddWithValue("codigo1", empleado.Codigo);
                    Script.Parameters.AddWithValue("codigo2", horario.Codigo);

                    Script.Prepare();

                    Script.ExecuteNonQuery();
                }

                CerrarConexion();
            }
            catch (Exception ex)
            {
               
            }

        }

        public void Eliminar(Empleado empleado, Beneficio beneficio)
        {
            try
            {
                if (AbrirConexion())
                {
                    string Commando = "DELETE FROM em_be " +
                        "WHERE (empleado_em_codigo = @codigo1) AND (beneficio_be_codigo = @codigo2)";
                    Script = new NpgsqlCommand(Commando, Conexion);

                    Script.Parameters.AddWithValue("codigo1", empleado.Codigo);
                    Script.Parameters.AddWithValue("codigo2", beneficio.Codigo);

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

        public void Eliminar(Empleado empleado, Cargo cargo)
        {
            if (AbrirConexion())
            {
                string Commando = "DELETE FROM em_ca " +
                    "WHERE (empleado_em_codigo = @codigo1) AND (cargo_ca_codigo = @codigo2)";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo1", empleado.Codigo);
                Script.Parameters.AddWithValue("codigo2", cargo.Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            CerrarConexion();
        }

        /*Modelo Eliminar de BD Muchos a Muchos
        public void Eliminar(Tipo1 tipo1, Tipo2 tipo2)
        {
            if(AbrirConexion())
            {
                string Commando = "DELETE FROM tabla WHERE (codigo1 = @codigo1) AND (codigo2 = @codigo2)";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo1", tipo1.Codigo);
                Script.Parameters.AddWithValue("codigo2", tipo2.Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }

            CerrarConexion();
        }
        */
        #endregion

        #region Actualizar atributos en los muchos a muchos
        public void Actualizar(Empleado empleado, Cargo cargo, DateTime fechaFin = new DateTime())
        {
            if (fechaFin.Year == 0001)
            {
                fechaFin = DateTime.Today;
            }

            if (AbrirConexion())
            {
                string Comando = "UPDATE em_ca SET fecha_fin = @fecha " +
                    "WHERE (empleado_em_codigo = @empleado) AND (cargo_ca_codigo = @cargo)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("fecha", fechaFin);
                Script.Parameters.AddWithValue("empleado", empleado.Codigo);
                Script.Parameters.AddWithValue("cargo", cargo.Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }

            CerrarConexion();
        }
        #endregion
        //devuelve el codigo del cargo donde trabaja
        public int BuscarEnCargo(Empleado codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM em_ca WHERE empleado_em_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo.Codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return ReadInt(1);
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

            return 0;
        }


        #region Manejo de Conexion
        private bool AbrirConexion()
        {
            try
            {
                Conexion.Open();

                return true;
            }
            catch
            {
                CerrarConexion();
            }

            return false;
        }

        private void CerrarConexion()
        {
            try
            {
                Conexion.Close();
            }
            finally { }
        }


        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>int</c></returns>
        public int ReadInt(int posicion)
        {
            try
            {
                return Reader.GetInt32(posicion);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        #endregion
    }
}