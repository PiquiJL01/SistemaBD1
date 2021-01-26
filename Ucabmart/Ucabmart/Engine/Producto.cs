using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Producto : ConexionBD<Producto, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool EsAlimenticio { get; set; }
        public float Precio { get; set; }
        public string Calidad { get; set; }
        public string Descripcion { get; set; }
        public int CodigoMarca { get; set; }
        public int CodigoClasificacion { get; set; }
        #endregion

        #region Declaraciones
        public Producto(string nombre, bool esAlimenticio, float precio, TipoCalidad calidad,
            string descrpcion, Marca marca, Clasificacion clasificacion)
        {
            Nombre = nombre;
            EsAlimenticio = esAlimenticio;
            Precio = precio;
            switch (calidad)
            {
                case TipoCalidad.Alta:
                    Calidad = "Alta";
                    break;
                case TipoCalidad.Baja:
                    Calidad = "Baja";
                    break;
                case TipoCalidad.Regular:
                    Calidad = "Regular";
                    break;
                default:
                    Calidad = null;
                    break;
            }
            Descripcion = descrpcion;
            CodigoMarca = marca.Codigo;
            CodigoClasificacion = clasificacion.Codigo;
        }

        public Producto(int codigo)
        {
            Producto producto = Leer(codigo);
            if (!(producto == null))
            {
                Codigo = producto.Codigo;
                Nombre = producto.Nombre;
                EsAlimenticio = producto.EsAlimenticio;
                Precio = producto.Precio;
                Calidad = producto.Calidad;
                Descripcion = producto.Descripcion;
                CodigoMarca = producto.CodigoMarca;
                CodigoClasificacion = producto.CodigoClasificacion;
            }
        }

        public Producto()
        {
        }


        private Producto(int codigo, string nombre, bool esAlimenticio, float precio,
        string calidad, string descripcion, int marca, int clasificacion)
        {
            Codigo = codigo;
            Nombre = nombre;
            EsAlimenticio = esAlimenticio;
            Precio = precio;
            Calidad = Calidad;
            Descripcion = descripcion;
            CodigoMarca = marca;
            CodigoClasificacion = clasificacion;
        }
        #endregion

        public List<int> ProductosCod(List<String> items)
        {
            Producto p1 = new Producto();

            List<Producto> productos = new List<Producto>();
            productos = p1.Todos();
            List<int> lista = new List<int>();

            foreach (Producto producto in productos)
            {
                if (items.Contains(producto.Nombre))
                {
                    lista.Add(producto.Codigo);
                }
            }

            return lista;

        }

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO producto (pr_nombre, pr_es_alimenticio, pr_precio, pr_calidad, pr_descripcion, marca_ma_codigo, clasificacion_cl_codigo) " +
                    "VALUES (@nombre, @alimenticio, @precio, @calidad, @descripcion, @marca, @clasificacion) RETURNING pr_codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("alimenticio", EsAlimenticio);
                Script.Parameters.AddWithValue("precio", Precio);
                Script.Parameters.AddWithValue("calidad", Calidad);
                Script.Parameters.AddWithValue("descripcion", Descripcion);
                Script.Parameters.AddWithValue("marca", CodigoMarca);
                Script.Parameters.AddWithValue("clasificacion", CodigoClasificacion);

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

        public override Producto Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM producto WHERE pr_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Producto(ReadInt(0), ReadString(1), ReadBool(2), ReadFloat(3), ReadString(4), ReadString(5), ReadInt(5), ReadInt(6));
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

        public override List<Producto> Todos()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM producto";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Producto producto = new Producto(ReadInt(0), ReadString(1), ReadBool(2),
                        ReadFloat(3), ReadString(4), ReadString(5), ReadInt(5), ReadInt(6));

                    lista.Add(producto);
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

                string Comando = "UPDATE producto SET pr_nombre = @nombre, pr_es_alimenticio = @alimenticio, " +
                    "pr_precio = @precio, pr_calidad = @calidad, pr_descripcion = @descripcion, marca_ma_codigo = @marca, " +
                    "clasificacion_cl_codigo = @clasificacion  WHERE pr_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("alimenticio", EsAlimenticio);
                Script.Parameters.AddWithValue("precio", Precio);
                Script.Parameters.AddWithValue("calidad", Calidad);
                Script.Parameters.AddWithValue("descripcion", Descripcion);
                Script.Parameters.AddWithValue("marca", CodigoMarca);
                Script.Parameters.AddWithValue("clasificacion", CodigoClasificacion);

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

                string Commando = "DELETE FROM producto WHERE pr_codigo = @codigo";
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