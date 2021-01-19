using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Natural : Cliente
    {
        #region Atributos
        public string Cedula { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Direccion { get; set; }
        #endregion

        #region Declaraciones
        public Natural(string rif, string password, CorreoElectronico email, string cedula,
            string nombre1, string nombre2, string apellido1, string apellido2, Lugar direccion, Tienda tienda = null)
            : base(rif, password, email, tienda)
        {
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Direccion = direccion.Codigo;
        }

        private Natural(string rif, string cedula,
            string nombre1, string nombre2, string apellido1, string apellido2, int direccion)
            : base(rif)
        {
            Cedula = cedula;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Direccion = direccion;
        }

        public Natural(string rif) : base(rif)
        {
            Natural natural = LeerNatural(rif);
            if (!(natural == null))
            {

                Cedula = natural.Cedula;
                Nombre1 = natural.Nombre1;
                Nombre2 = natural.Nombre2;
                Apellido1 = natural.Apellido1;
                Apellido2 = natural.Apellido2;
                Direccion = natural.Direccion;
            }
        }

        public Natural()
        {
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                base.Insertar();

                Conexion.Open();

                string Comando = "INSERT INTO naturales (cl_rif, na_cedula, na_1er_nombre, na_2do_nombre, na_1er_apellido, na_2do_apellido, lugar_lu_codigo) " +
                    "VALUES (@rif, @cedula, @nombre1, @nombre2, @apellido1, @apellido2, @direccion)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", RIF);
                Script.Parameters.AddWithValue("cedula", Cedula);
                Script.Parameters.AddWithValue("nombre1", Nombre1);
                Script.Parameters.AddWithValue("nombre2", Nombre2);
                Script.Parameters.AddWithValue("apellido1", Apellido1);
                Script.Parameters.AddWithValue("apellido2", Apellido2);
                Script.Parameters.AddWithValue("direccion", Direccion);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }

        public Natural LeerNatural(string codigo)
        {
            string rif = null;
            string cedula = null;
            string nombre1 = null;
            string nombre2 = null;
            string apellido1 = null;
            string apellido2 = null;
            int direccion = 0;

            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM naturales WHERE cl_rif=@rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    rif = ReadString(0);
                    cedula = ReadString(1);
                    nombre1 = ReadString(2);
                    nombre2 = ReadString(3);
                    apellido1 = ReadString(4);
                    apellido2 = ReadString(5);
                    direccion = ReadInt(6);
                }


            }

            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                Conexion.Close();
            }

            Natural natural = new Natural(rif, cedula, nombre1, nombre2, apellido1, apellido2, direccion);
            return natural;
        }

        public List<Natural> TodosNaturales()
        {
            List<Natural> lista = new List<Natural>();
            string rif = null;
            string cedula = null;
            string nombre1 = null;
            string nombre2 = null;
            string apellido1 = null;
            string apellido2 = null;
            int direccion = 0;

            List<Natural> listaNatural = new List<Natural>();
            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM naturales";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    // Claves.Add(ReadString(0));
                    rif = ReadString(0);
                    cedula = ReadString(1);
                    nombre1 = ReadString(2);
                    nombre2 = ReadString(3);
                    apellido1 = ReadString(4);
                    apellido2 = ReadString(5);
                    direccion = ReadInt(6);
                    Natural natural = new Natural(rif, cedula, nombre1, nombre2, apellido1, apellido2, direccion);
                    listaNatural.Add(natural);
                }

                //foreach (string clave in Claves)
                //{
                //    lista.Add(new Natural(clave));
                //}
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                Conexion.Close();
            }

            return listaNatural;
        }

        public override void Actualizar()
        {
            try
            {
                base.Actualizar();

                Conexion.Open();

                string Comando = "UPDATE naturales SET na_cedula = @cedula, na_1er_nombre = @nombre1, na_2do_nombre = @nombre2, " +
                    "na_1er_apellido = @ apellido1, na_2do_apellido = @apellido2, lugar_lu_codigo = @direccion WHERE cl_rif = @rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", RIF);
                Script.Parameters.AddWithValue("cedula", Cedula);
                Script.Parameters.AddWithValue("nombre1", Nombre1);
                Script.Parameters.AddWithValue("nombre2", Nombre2);
                Script.Parameters.AddWithValue("apellido1", Apellido1);
                Script.Parameters.AddWithValue("apellido2", Apellido2);
                Script.Parameters.AddWithValue("direccion", Direccion);

                Script.Prepare();

                Script.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                Conexion.Close();
            }
        }

        public override void Eliminar()
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM naturales WHERE cl_rif = @rif";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("rif", RIF);

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