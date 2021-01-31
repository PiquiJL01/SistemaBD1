using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Zona : ConexionBD<Zona, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int CodigoPasilloTienda { get; set; }
        public int CodigoPasillo { get; set; }
        public int CodigoAlmacen { get; set; }
        public string Tipo { get; set; }
        #endregion

        #region Declaraciones
        public Zona(string nombre, Pasillo pasillo)
        {
            Nombre = nombre;
            CodigoPasilloTienda = pasillo.CodigoTienda;
            CodigoPasillo = pasillo.Codigo;
            CodigoAlmacen = 0;
            Tipo = null;
        }

        public Zona(string nombre, Almacen almacen, TipoZona tipoZona)
        {
            Nombre = nombre;
            CodigoPasilloTienda = 0;
            CodigoPasillo = 0;
            CodigoAlmacen = almacen.Codigo;
            switch (tipoZona)
            {
                case TipoZona.Congelador:
                    Tipo = "Congelador";
                    break;
                case TipoZona.General:
                    Tipo = "General";
                    break;
                case TipoZona.Refrigerador:
                    Tipo = "Refrigerador";
                    break;
                default:
                    break;
            }
        }

        public Zona(int codigo)
        {
            Zona zona = Leer(codigo);
            if (!(zona == null))
            {
                Codigo = zona.Codigo;
                Nombre = zona.Nombre;
                CodigoPasilloTienda = zona.CodigoPasilloTienda;
                CodigoPasillo = zona.CodigoPasillo;
                CodigoAlmacen = zona.CodigoAlmacen;
                Tipo = zona.Tipo;
            }
        }

        private Zona(int codigo, string nombre, int tiendaPasillo, int pasillo, int almacen, string tipo)
        {
            Codigo = codigo;
            Nombre = nombre;
            CodigoPasilloTienda = tiendaPasillo;
            CodigoPasillo = pasillo;
            CodigoAlmacen = almacen;
            Tipo = tipo;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                if (CodigoAlmacen == 0)
                {
                    string Comando = "INSERT INTO zona (zo_nombre, pasillo_tienda_ti_codigo, pasillo_pa_codigo) " +
                        "VALUES (@nombre, @tienda, @pasillo) RETURNING zo_codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("nombre", Nombre);
                    Script.Parameters.AddWithValue("tienda", CodigoPasilloTienda);
                    Script.Parameters.AddWithValue("paasillo", CodigoPasillo);
                }
                else
                {
                    string Comando = "INSERT INTO zona (zo_nombre, almacen_al_codigo, tipo) " +
                        "VALUES (@nombre, @almacen, @tipo) RETURNING zo_codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("nombre", Nombre);
                    Script.Parameters.AddWithValue("almacen", CodigoAlmacen);
                    Script.Parameters.AddWithValue("tipo", Tipo);
                }

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

        public override Zona Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM zona WHERE zo_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Zona(ReadInt(0), ReadString(1), ReadInt(2), ReadInt(3), ReadInt(4), ReadString(5));
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

        public override List<Zona> Todos()
        {
            List<Zona> lista = new List<Zona>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM zona";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Zona zona = new Zona(ReadInt(0), ReadString(1), ReadInt(2), ReadInt(3), ReadInt(4), ReadString(5));

                    lista.Add(zona);
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

                if (CodigoAlmacen == 0)
                {
                    string Comando = "UPDATE zona SET zo_nombre = @nombre, pasillo_tienda_ti_codigo = @tienda, pasillo_pa_codigo = @pasillo " +
                        "WHERE zo_codigo = @codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("codigo", Codigo);
                    Script.Parameters.AddWithValue("@nommbre", Nombre);
                    Script.Parameters.AddWithValue("@tienda", CodigoPasilloTienda);
                    Script.Parameters.AddWithValue("@pasillo", CodigoPasillo);
                }
                else
                {
                    string Comando = "UPDATE zona SET zo_nombre = @nombre, almacen_al_codigo = @almacen, tipo = @tipo " +
                        "WHERE zo_codigo = @codigo";
                    Script = new NpgsqlCommand(Comando, Conexion);

                    Script.Parameters.AddWithValue("codigo", Codigo);
                    Script.Parameters.AddWithValue("nombre", Nombre);
                    Script.Parameters.AddWithValue("almacen", CodigoAlmacen);
                    Script.Parameters.AddWithValue("tipo", Tipo);
                }

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

                string Commando = "DELETE FROM zona WHERE zo_codigo = @codigo";
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