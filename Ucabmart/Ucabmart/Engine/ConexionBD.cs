using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace Ucabmart.Engine
{
    public abstract class ConexionBD<Tipo, Codigo>
    {
        private const string ConnectionString = "Host = labs-dbservices01.ucab.edu.ve; User Id = grupo5bd1; Password = 123456789; Database = grupo5db";
        public NpgsqlCommand Script;
        public NpgsqlDataReader Reader;
        public NpgsqlConnection Conexion = new NpgsqlConnection(ConnectionString);

        #region CRUDs
        /// <summary>
        /// Inserta en la base de datos
        /// </summary>
        /// <param name="objeto"></param>
        public abstract void Insertar();
        //Codigo Viejo
        /*{
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

        //public abstract void ScriptInsertar();

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
        #endregion
    }
}