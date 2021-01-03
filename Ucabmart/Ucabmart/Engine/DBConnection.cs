using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace Ucabmart.Engine
{
    public class DBConnection
    {

        private string ConnectionString;
        private string Command;
        private NpgsqlCommand Script;
        private NpgsqlDataReader Reader;
        private NpgsqlConnection Connection;

        #region Private Methods
        /// <summary>
        /// <c>Clase</c> para la conexion con la BD
        /// </summary>
        public DBConnection()
        {
            ConnectionString = "Host = labs-dbservices01.ucab.edu.ve; User Id = jlgil18; Password = inmunda01; Database = testconnectionjlgz";

            Connection = new NpgsqlConnection("Host = labs-dbservices01.ucab.edu.ve; User Id = jlgil18; Password = inmunda01; Database = testconnectionjlgz");
        }

        /// <summary>
        /// Abre la conexion con la <c>BD</c>
        /// </summary>
        private void OpenConnection()
        {
            Connection.Open();
        }


        /// <summary>
        /// Cierra la conexion con la <c>BD</c>
        /// </summary>
        private void CloseConnection()
        {
            Connection.Close();

        }
        #endregion

        /// <summary>
        /// Prueba de conexion de la base de datos
        /// </summary>
        public void Test()
        {
            OpenConnection();

            CloseConnection();
        }

        #region CRUDs

        #region Alamcenes
        /// <summary>
        /// Inserta en la <c>BD</c>
        /// </summary>
        /// <param name="almacen">Objeto a insertar</param>
        public void InsertarAlmacen(Almacen almacen)
        {
            try
            {
                OpenConnection();

                Command = "INSERT INTO alamcenes(codigo) VALUES(@codigo)";
                Script = new NpgsqlCommand(Command, Connection);

                Script.Parameters.AddWithValue("codigo", almacen.Codigo);
                Script.Prepare();

                Script.ExecuteNonQuery();

                CloseConnection();
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Obtiene una lista con todos los alamcenes
        /// </summary>
        public List<Almacen> ListaAlmacenes()
        {
            List<Almacen> lista = new List<Almacen>();

            try
            {
                OpenConnection();
                
                Command = "SELECT * FROM almacenes";
                Script = new NpgsqlCommand(Command, Connection);
                
                Reader = Script.ExecuteReader();
                  
                //Ejemplo de los headers de cada columna de la tabla
                //Console.WriteLine($"{rdr.GetName(0),-4} {rdr.GetName(1),-10} {rdr.GetName(2),10}");
                
                while (Reader.Read())
                {
                    // ejemplo para la consola
                    //Console.WriteLine($"{rdr.GetInt32(0),-4} {rdr.GetString(1),-10} {rdr.GetInt32(2),10}");

                    Almacen almacen = new Almacen(Reader.GetInt32(0));
                    lista.Add(almacen);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return lista;
        }

        /// <summary>
        /// Busca un almacen en la <c>BD</c>
        /// </summary>
        /// <param name="codigo">Identificador en la <c>BD</c></param>
        /// <returns>Almacen Buscado</returns>
        public Almacen BuscarAlmacen(int codigo)
        {
            Almacen almacen = null;
            try
            {
                OpenConnection();

                Command = "SELECT * FROM alamacenes WHERE codigo=@valor";
                Script = new NpgsqlCommand(Command, Connection);

                Script.Parameters.AddWithValue("valor", 1654);
                NpgsqlDataReader rdr = Script.ExecuteReader();

                if (rdr.Read())
                {
                    almacen = new Almacen(rdr.GetInt32(0));
                }

                CloseConnection();
            }
            catch (Exception e)
            {

            }

            return almacen;
        }

        /// <summary>
        /// Actualizar informacion del almacen en la <c>BD</c>
        /// </summary>
        /// <param name="almacen"></param>
        public void ActualizarAlmacen(Almacen almacen)
        {
            BuscarAlmacen(1233);
            if (!(BuscarAlmacen(almacen.Codigo)==null))
            {
                OpenConnection();
                string
            }
        }
        #endregion
        #endregion
    }
}