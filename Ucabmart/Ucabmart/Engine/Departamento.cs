using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Departamento : ConexionBD<Departamento, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Declaraciones
        public Departamento(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = Descripcion;
        }

        public Departamento(int codigo)
        {
            Departamento departamento = Leer(codigo);
            if (!(departamento == null))
            {
                Codigo = departamento.Codigo;
                Nombre = departamento.Nombre;
                Descripcion = departamento.Descripcion;
            }
        }

        private Departamento(int codigo, string nombre, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Departamento()
        {
        }

        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO departamento (de_nombre, de_descripcion) VALUES (@nombre, @descripcion) RETURNING de_codigo";
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

        public override Departamento Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM departamento WHERE de_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Departamento(ReadInt(0), ReadString(1), ReadString(2));
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

        public override List<Departamento> Todos()
        {
            List<Departamento> lista = new List<Departamento>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM departamento";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Departamento departamento = new Departamento(ReadInt(0), ReadString(1), ReadString(2));

                    lista.Add(departamento);
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

                string Comando = "UPDATE tabla SET de_nombre = @nombre, de_descripcion = @descripcion WHERE de_codigo = @codigo";
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

                string Commando = "DELETE FROM departamento WHERE de_codigo = @codigo";
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
        public int Get_CodDepartamento(String Name)
        {
            List<Departamento> departamentos = this.Todos();

            foreach (Departamento departamento in departamentos)
            {
                if (departamento.Nombre == Name)
                {
                    return departamento.Codigo;
                }
            }
            return -1;
        }
        #endregion
    }
}