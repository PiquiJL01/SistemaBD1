using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace Ucabmart.Engine
{
    public abstract class ConexionBD<Tipo, Codigo>
    {
        /**/
        private const string ConnectionString = "Host = labs-dbservices01.ucab.edu.ve; User Id = grupo5bd1; Password = 123456789; Database = grupo5db";
        private string Comando;
        public NpgsqlCommand Script;
        public NpgsqlDataReader Reader;
        public NpgsqlConnection Conexion = new NpgsqlConnection(ConnectionString);

        /// <summary>
        /// Prueba de conexion de la base de datos
        /// </summary>
        public void Test()
        {

        }

        #region CRUDs


        /// <summary>
        /// Inserta en la base de datos
        /// </summary>
        /// <param name="objeto"></param>
        public void Insertar()
        {
            try
            {

                ConnectOpenConnection();

                Script = ScriptInsertar();
                
                Script.Prepare();

                Script.ExecuteNonQuery();

                CloseConnection();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public abstract void ScriptInsertar();

        /// <summary>
        /// Busca en la Base de Datos
        /// </summary>
        /// <returns>Lista con todos los objetos de la tabla de la <typeparamref name="Clase"/></returns>
        public abstract List<Tipo> Todos();

        /// <summary>
        /// Busca especificamente en la base de datos
        /// </summary>
        /// <param name="codigo">Codigo para la busqueda</param>
        /// <returns></returns>
        public abstract Tipo Leer(Codigo codigo);


        /* CRUDs Originales
        #region Alamcenes
        
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

                   // Almacen almacen = new Almacen(Reader.GetInt32(0));
                 //   lista.Add(almacen);
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

                //if (rdr.Read())
                //{
                //    almacen = new Almacen(rdr.GetInt32(0));
                //}

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
        }
        #endregion

        #region Lugar
        /// <summary>
        /// Inserta en la <c>BD</c>
        /// </summary>
        /// <param name="lugar">Objeto a insertar</param>
        public void InsertarLugar(Lugar lugar)
        {
            try
            {

                OpenConnection();

                if (lugar.CodigoUbicacion==null)
                {
                    Command = "INSERT INTO lugar (lu_codigo, lu_nombre, lu_tipo, lu_descripcion) VALUES (@codigo, @nombre, @tipo, @descripcion)";
                    Script = new NpgsqlCommand(Command, Connection);

                    Script.Parameters.AddWithValue("codigo", lugar.Codigo);
                    Script.Parameters.AddWithValue("nombre", lugar.Nombre);
                    Script.Parameters.AddWithValue("tipo", lugar.Tipo);
                    Script.Parameters.AddWithValue("descripcion", lugar.Descripcion);
                }
                else
                {
                    Command = "INSERT INTO lugar (lu_codigo, lu_nombre, lu_tipo, lu_descripcion, lugar_lu_codigo) VALUES (@codigo, @nombre, @tipo, @descripcion, @lugar)";
                    Script = new NpgsqlCommand(Command, Connection);

                    Script.Parameters.AddWithValue("codigo", lugar.Codigo);
                    Script.Parameters.AddWithValue("nombre", lugar.Nombre);
                    Script.Parameters.AddWithValue("tipo", lugar.Tipo);
                    Script.Parameters.AddWithValue("descripcion", lugar.Descripcion);
                    Script.Parameters.AddWithValue("lugar", lugar.CodigoUbicacion);
                }
                Script.Prepare();

                Script.ExecuteNonQuery();

                CloseConnection();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Obtiene una lista con todos los alamcenes
        /// </summary>
        public List<Almacen> ListaLugar()
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

                    // Almacen almacen = new Almacen(Reader.GetInt32(0));
                    //   lista.Add(almacen);
                }
            }
            catch (Exception e)
            {
                CloseConnection();
                throw e;
            }

            CloseConnection();
            return lista;
        }

        /// <summary>
        /// Busca un almacen en la <c>BD</c>
        /// </summary>
        /// <param name="codigo">Identificador en la <c>BD</c></param>
        /// <returns>Almacen Buscado</returns>
        public Almacen BuscarLugar(int codigo)
        {
            Almacen almacen = null;
            try
            {
                OpenConnection();

                Command = "SELECT * FROM alamacenes WHERE codigo=@valor";
                Script = new NpgsqlCommand(Command, Connection);

                Script.Parameters.AddWithValue("valor", 1654);
                NpgsqlDataReader rdr = Script.ExecuteReader();

                //if (rdr.Read())
                //{
                //    almacen = new Almacen(rdr.GetInt32(0));
                //}

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
        public void ActualizarLugar(Almacen almacen)
        {
            BuscarAlmacen(1233);
            if (!(BuscarAlmacen(almacen.Codigo) == null))
            {
                OpenConnection();
                // string
            }
        }
        #endregion
        */
        #endregion
    }
}