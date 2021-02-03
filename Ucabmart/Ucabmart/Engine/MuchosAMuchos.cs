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
        //private const string ConnectionString = "Host = labs-dbservices01.ucab.edu.ve; User Id = jlgil18; Password = inmunda01; Database = testconnection "; //conexion de pruebas
        private NpgsqlCommand Script;
        private NpgsqlConnection Conexion = new NpgsqlConnection(ConnectionString);
        #endregion

        #region Declaraciones
        public MuchosAMuchos()
        {

        }

        #endregion

        #region Insertar
        public void Insertar(Empleado empleado, Horario horario)
        {
            if(AbrirConexion())
            {
                string Comando = "INSERT INTO em_ho (empleado_em_codigo, horario_ho_codigo) VALUES (@empleado, horario)";
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
                    "VALUES (@codigo1, codigo2, @fecha, @monto)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo1", empleado.Codigo);
                Script.Parameters.AddWithValue("codigo2", beneficio.Codigo);
                Script.Parameters.AddWithValue("@fecha", fecha);
                Script.Parameters.AddWithValue("monto", monto);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }

            CerrarConexion();
        }

        /* Modelo para Insertar en BD una entidad Muchos a Muchos
        public void Insertar(Tipo1 tipo1, Tipo2 tipo2)
        {
            if(AbrirConexion())
            {
                string Comando = "INSERT INTO tabla (codigo1, codigo2) VALUES (@codigo1, codigo2)";
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
                Conexion.Open();

                string Commando = "DELETE FROM tabla WHERE (codigo1 = @codigo1) AND (codigo2 = @codigo2";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo1", empleado.Codigo);
                Script.Parameters.AddWithValue("codigo2", horario.Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                try
                {
                    Conexion.Close();
                }
                finally { }
            }
        }

        public void Eliminar(Empleado empleado, Beneficio beneficio)
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM em_be " +
                    "WHERE (empleado_em_codigo = @codigo1) AND (beneficio_be_codigo = @codigo2)";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo1", empleado.Codigo);
                Script.Parameters.AddWithValue("codigo2", beneficio.Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                try
                {
                    Conexion.Close();
                }
                finally { }
            }
        }

        /*Modelo Eliminar de BD Muchos a Muchos
        public void Eliminar(Tipo1 tipo1, Tipo2 tipo2)
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM tabla WHERE (codigo1 = @codigo1) AND (codigo2 = @codigo2)";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo1", tipo1.Codigo);
                Script.Parameters.AddWithValue("codigo2", tipo2.Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
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
        */
        #endregion

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
        #endregion
    }
}