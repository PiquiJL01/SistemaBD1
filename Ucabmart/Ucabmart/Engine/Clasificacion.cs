using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Clasificacion : ConexionBD<Clasificacion, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Declaraciones
        public Clasificacion(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Clasificacion(int codigo)
        {
            Clasificacion clasificacion = Leer(codigo);
            if (!(clasificacion == null))
            {
                Codigo = clasificacion.Codigo;
                Nombre = clasificacion.Nombre;
                Descripcion = clasificacion.Descripcion;
            }
        }

        private Clasificacion(int codigo, string nombre, string descripción)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripción;
        }

        public Clasificacion()
        {

        }

        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO clasificacion (cl_nombre, cl_descripcion) VALUES (@nombre, @descripcion) RETURNING cl_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

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

        public override Clasificacion Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM clasificacion WHERE cl_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Clasificacion(ReadInt(0), ReadString(1), ReadString(2));
                }

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
            }

            return null;
        }

        public override List<Clasificacion> Todos()
        {
            List<Clasificacion> lista = new List<Clasificacion>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM clasificacion";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Clasificacion clasificacion = new Clasificacion(ReadInt(0), ReadString(1), ReadString(2));

                    lista.Add(clasificacion);
                }
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
                return null;
            }

            return lista;
        }

        public override void Actualizar()
        {
            try
            {
                Conexion.Open();

                string Comando = "UPDATE calsificacion SET cl_nombre = @nombre, cl_descripcion = @descripcion WHERE cl_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

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
            }
        }

        public override void Eliminar()
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM tabla WHERE cl_codigo = @codigo";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

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
            }
        }
        #endregion

        #region Otros Metodos

        public int Get_Clasificacion(String Name)
        {
            List<Clasificacion> clasificaciones = this.Todos();

            foreach (Clasificacion clasificacion in clasificaciones)
            {
                if (clasificacion.Nombre == Name)
                {
                    return clasificacion.Codigo;
                }
            }
            return -1;
        }

        #endregion



    }
}