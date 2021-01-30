using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Tarjeta : MetodoDePago
    {
        #region Atributos
        public string Tipo { get; set; }
        public int Numero { get; set; }
        public int CVV { get; set; }
        public string NombreImpreso { get; set; }
        public DateTime FechaVencimiento { get; set; }
        #endregion

        #region Declaraciones
        public Tarjeta(string nombre, string descripcion, DateTime fecha, TipoTarjeta tipo,
            int numero, int cvv, string nombreimpreso, DateTime fechaVencimiento)
            : base(nombre, descripcion, fecha)
        {
            switch (tipo)
            {
                case TipoTarjeta.AmericanExpress:
                    Tipo = "American Express";
                    break;
                case TipoTarjeta.Debito:
                    Tipo = "Debito";
                    break;
                case TipoTarjeta.DinersClub:
                    Tipo = "Diner´s Club";
                    break;
                case TipoTarjeta.Discovery:
                    Tipo = "Discovery";
                    break;
                case TipoTarjeta.Maestro:
                    Tipo = "Maestro";
                    break;
                case TipoTarjeta.MasterCard:
                    Tipo = "MasterCard";
                    break;
                case TipoTarjeta.Visa:
                    Tipo = "Visa";
                    break;
                default:
                    Tipo = null;
                    break;
            }
            Numero = numero;
            CVV = cvv;
            NombreImpreso = nombreimpreso;
            FechaVencimiento = fechaVencimiento;
        }

        public Tarjeta(int codigo)
        {
            Tarjeta tarjeta = LeerTarjeta(codigo);
            if (!(tarjeta == null))
            {
                Nombre = tarjeta.Nombre;
                Descripcion = tarjeta.Descripcion;
                Fecha = tarjeta.Fecha;
                Tipo = tarjeta.Tipo;
                Numero = tarjeta.Numero;
                CVV = tarjeta.CVV;
                NombreImpreso = tarjeta.NombreImpreso;
                FechaVencimiento = tarjeta.FechaVencimiento;
            }
        }

        private Tarjeta(int codigo, string tipo, int numero, int cvv, string nombreImpreso, DateTime fechaVencimiento) : base(codigo)
        {
            Tipo = tipo;
            Numero = numero;
            CVV = cvv;
            NombreImpreso = nombreImpreso;
            FechaVencimiento = fechaVencimiento;
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                base.Insertar();

                Conexion.Open();

                string Comando = "INSERT INTO tarjeta (mp_codigo, ta_tipo, ta_numero, ta_cvv, ta_nombre_impreso, ta_fecha_vencimiento) " +
                    "VALUES (@codigo, @tipo, @numero, @cvv, @nombre, @fecha)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("tipo", Tipo);
                Script.Parameters.AddWithValue("numero", Numero);
                Script.Parameters.AddWithValue("cvv", CVV);
                Script.Parameters.AddWithValue("nombre", NombreImpreso);
                Script.Parameters.AddWithValue("fecha", FechaVencimiento);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }

        public Tarjeta LeerTarjeta(int codigo)
        {
            int clave = 0;
            string tipo = null;
            int numero = 0;
            int cvv = 0;
            string nombreImpreso = null;
            DateTime fechaVencimiento = new DateTime();
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM tarjeta WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    clave = ReadInt(0);
                    tipo = ReadString(1);
                    numero = ReadInt(2);
                    cvv = ReadInt(3);
                    nombreImpreso = ReadString(4);
                    fechaVencimiento = ReadDate(5);
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
                return null;
            }
            Tarjeta tarjeta = new Tarjeta(clave, tipo, numero, cvv, nombreImpreso, fechaVencimiento);
            return tarjeta;
        }

        public List<Tarjeta> TodasTarjetas()
        {
            List<Tarjeta> lista = new List<Tarjeta>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM tarjeta";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                List<int> claves = new List<int>();

                while (Reader.Read())
                {
                    claves.Add(ReadInt(0));
                }

                Conexion.Close();

                foreach (int clave in claves)
                {
                    lista.Add(new Tarjeta(clave));
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
                base.Actualizar();

                Conexion.Open();
                string Comando = "UPDATE tarjeta SET ta_tipo = @tipo, ta_numero = @numero, ta_cvv = @cvv, ta_nombre_impreso = @nombre, ta_fecha_vencimiento = @fecha " +
                    "WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("tipo", Tipo);
                Script.Parameters.AddWithValue("numero", Numero);
                Script.Parameters.AddWithValue("cvv", CVV);
                Script.Parameters.AddWithValue("nombre", NombreImpreso);
                Script.Parameters.AddWithValue("fecha", Fecha);

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

                string Commando = "DELETE FROM tarjeta WHERE mp_codigo = @codigo";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();

                base.Eliminar();
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