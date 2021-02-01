using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Cargo : ConexionBD<Cargo, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Declaraciones
        public Cargo(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Cargo(int codigo)
        {
            Cargo cargo = Leer(codigo);
            if (!(cargo == null))
            {
                Codigo = cargo.Codigo;
                Nombre = cargo.Nombre;
                Descripcion = cargo.Descripcion;
            }
        }

        private Cargo(int codigo, string nombre, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Cargo()
        {
        }

        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO cargo (ca_nombre, ca_descripcion) VALUES (@nombre, @descripcion) RETURNING ca_codigo";
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

        public override Cargo Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM cargo WHERE ca_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Cargo(ReadInt(0), ReadString(1), ReadString(2));
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

        public override List<Cargo> Todos()
        {
            List<Cargo> lista = new List<Cargo>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM cargo";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Cargo cargo = new Cargo(ReadInt(0), ReadString(1), ReadString(2));

                    lista.Add(cargo);
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

                string Comando = "UPDATE cargo SET ca_nombre = @nombre, ca_descripcion = @descripcion WHERE ca_codigo = @codigo";
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

                string Commando = "DELETE FROM cargo WHERE ca_codigo = @codigo";
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


        public int Get_CodCargo(String Name)
        {
            List<Cargo> cargos = this.Todos();

            foreach (Cargo cargo in cargos)
            {
                if (cargo.Nombre == Name)
                {
                    return cargo.Codigo;
                }
            }
            return -1;
        }

        #endregion

    }
}