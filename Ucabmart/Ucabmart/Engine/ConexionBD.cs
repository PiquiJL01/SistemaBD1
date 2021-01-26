using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public abstract class ConexionBD<Tipo, Codigo>
    {
        #region Atributos para establecer la conexion
        private const string ConnectionString = "Host = labs-dbservices01.ucab.edu.ve; User Id = grupo5bd1; Password = 123456789; Database = grupo5db"; //conexion a la bd del proyecto
        //private const string ConnectionString = "Host = labs-dbservices01.ucab.edu.ve; User Id = jlgil18; Password = inmunda01; Database = testconnection "; //conexion de pruebas
        public NpgsqlCommand Script;
        public NpgsqlDataReader Reader;
        public NpgsqlConnection Conexion = new NpgsqlConnection(ConnectionString);
        #endregion

        #region CRUDs
        /// <summary>
        /// Inserta <typeparamref name="Tipo"/> en la BD 
        /// </summary>
        public abstract void Insertar();

        /// <summary>
        /// Busca <typeparamref name="Tipo"/> en la Base de Datos
        /// </summary>
        /// <returns>Lista con todos los objetos de la tabla de la <typeparamref name="Tipo"/></returns>
        public abstract List<Tipo> Todos();


        /// <summary>
        /// Busca especificamente <typeparamref name="Tipo"/> en la base de datos
        /// </summary>
        /// <param name="codigo">Codigo de tipo <typeparamref name="Codigo"/> para la busqueda</param>
        /// <returns>La instancia especifica en la tabla de <typeparamref name="Tipo"/></returns>
        public abstract Tipo Leer(Codigo codigo);


        /// <summary>
        /// Actualiza a informacion de <typeparamref name="Tipo"/> en la BD
        /// </summary>
        public abstract void Actualizar();

        /// <summary>
        /// Elimina a <typeparamref name="Tipo"/> de la BD
        /// </summary>
        public abstract void Eliminar();
        #endregion

        #region Lectura con el Reader
        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>string</c></returns>
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


        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>float</c></returns>
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

        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>DateTime</c></returns>
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

        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>TimeSpan</c>, emula las horas</returns>
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

        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>bool</c></returns>
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