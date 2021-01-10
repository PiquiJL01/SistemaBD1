using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace Ucabmart.Engine
{
    public abstract class ConexionBD<Tipo, Codigo>
    {
        private const string ConnectionString = "Host = labs-dbservices01.ucab.edu.ve; User Id = grupo5bd1; Password = 123456789; Database = grupo5db"; //conexion a la bd del proyecto
        //private const string ConnectionString = "Host = labs-dbservices01.ucab.edu.ve; User Id = jlgil18; Password = inmunda01; Database = testconnection "; //conexion de pruebas
        public NpgsqlCommand Script;
        public NpgsqlDataReader Reader;
        public NpgsqlConnection Conexion = new NpgsqlConnection(ConnectionString);

        #region CRUDs
        /// <summary>
        /// Inserta en la BD
        /// </summary>
        public abstract void Insertar();
        /*{ //Codigo Viejo
            try
            {
                Conexion.Open();

                ScriptInsertar();
                
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
                throw e;
            }
        }*/

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


        /// <summary>
        /// Actualiza a informacion del <c>Objeto</c> en la BD
        /// </summary>
        public abstract void Actualizar();

        /// <summary>
        /// Elimina al <c>objeto</c> de la BD
        /// </summary>
        public abstract void Eliminar();
        #endregion

        #region Lectura con el Reader
        public string ReadString(int posicion)
        {
            try
            {
                return Reader.GetString(posicion);
            }
            catch (Exception e)
            {
                return null;
            }
        }

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

        public float ReadFloat(int posicion)
        {
            try
            {
                return Reader.GetFloat(posicion);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public DateTime ReadDate(int posicion)
        {
            try
            {
                return Reader.GetDateTime(posicion);
            }
            catch (Exception)
            {
                return new DateTime();
            }
        }

        public TimeSpan ReadTime(int posicion)
        {
            try
            {
                return Reader.GetTimeSpan(posicion);
            }
            catch (Exception)
            {
                return new TimeSpan();
            }
        }

        public bool ReadBool(int posicion)
        {
            try
            {
                return Reader.GetBoolean(posicion);
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion
    }
}