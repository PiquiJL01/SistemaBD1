using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Pasillo : ConexionBD<Pasillo, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CodigoTienda { get; set; }
        public int CodigoEmpleado { get; set; }
        #endregion

        #region Decalraciones
        public Pasillo(int numero, string nombre, string descripcion, Tienda tienda, Empleado empleado)
        {
            Numero = numero;
            Nombre = nombre;
            Descripcion = descripcion;
            CodigoTienda = tienda.Codigo;
            CodigoEmpleado = empleado.Codigo;
        }

        public Pasillo(int codigo)
        {
            Pasillo pasillo = Leer(codigo);
            if (!(pasillo == null))
            {
                Codigo = pasillo.Codigo;
                Numero = pasillo.Numero;
                Nombre = pasillo.Nombre;
                Descripcion = pasillo.Descripcion;
                CodigoTienda = pasillo.CodigoTienda;
                CodigoEmpleado = pasillo.CodigoEmpleado;
            }
        }

        private Pasillo(int codigo, int numero, string descripcion, int tienda, int empleado)
        {
            Codigo = codigo;
            Numero = numero;
            Descripcion = descripcion;
            CodigoTienda = tienda;
            CodigoEmpleado = empleado;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO pasillo (pa_numero, pa_nombre, pa_descripcion, tienda_ti_codigo, empleado_em_codigo) " +
                    "VALUES (@numero, @nombre, @descripcion, @tienda, @empleado) RETURNING pa_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("numero", Numero);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);
                Script.Parameters.AddWithValue("tienda", CodigoTienda);
                Script.Parameters.AddWithValue("ampleado", CodigoEmpleado);

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

        public override Pasillo Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM pasillo WHERE pa_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Pasillo(ReadInt(0), ReadInt(1), ReadString(2), ReadInt(3), ReadInt(4));
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

        public override List<Pasillo> Todos()
        {
            List<Pasillo> lista = new List<Pasillo>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM pasillo";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Pasillo pasillo = new Pasillo(ReadInt(0), ReadInt(1), ReadString(2), ReadInt(3), ReadInt(4));

                    lista.Add(pasillo);
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

                string Comando = "UPDATE pasillo SET pa_numero = @numero, pa_nombre = @nombre, pa_descripcion = @descripcion, " +
                    "tienda_ti_codigo = @tienda, empleado_em_codigo = @empleado WHERE pa_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("numero", Numero);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);
                Script.Parameters.AddWithValue("tienda", CodigoTienda);
                Script.Parameters.AddWithValue("empleado", CodigoEmpleado);

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

                string Commando = "DELETE FROM pasillo WHERE pa_codigo = @codigo";
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
    }
}