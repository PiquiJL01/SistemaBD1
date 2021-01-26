using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Juridico : Cliente
    {
        public string DenominacionComercial { get; set; }
        public string RazonSocial { get; set; }
        public float Capital { get; set; }
        public string PaginaWeb { get; set; }
        public int DireccionFisica { get; set; }
        public int DireccionFiscal { get; set; }

        #region Declaraciones
        public Juridico(string rif, string password, CorreoElectronico correo, string denominacionComercial,
            string razonSocial, float capital, string paginaWeb, int direccionFisica, int direccionFiscal, Tienda tienda = null)
            : base(rif, password, correo, tienda)
        {
            DenominacionComercial = denominacionComercial;
            RazonSocial = razonSocial;
            Capital = capital;
            PaginaWeb = paginaWeb;
            DireccionFisica = direccionFisica;
            DireccionFiscal = direccionFiscal;
        }

        private Juridico(string rif, string denominacionComercial, string razonSocial, float capital,
            string paginaWeb, int direccionFisica, int direccionFiscal) : base(rif)
        {
            DenominacionComercial = denominacionComercial;
            RazonSocial = razonSocial;
            Capital = capital;
            PaginaWeb = paginaWeb;
            DireccionFisica = direccionFisica;
            DireccionFiscal = direccionFiscal;
        }

        public Juridico(string rif) : base(rif)
        {
            Juridico juridico = LeerJuridico(rif);
            if (!(juridico == null))
            {
                DenominacionComercial = juridico.DenominacionComercial;
                RazonSocial = juridico.RazonSocial;
                Capital = juridico.Capital;
                PaginaWeb = juridico.PaginaWeb;
                DireccionFisica = juridico.DireccionFisica;
                DireccionFiscal = juridico.DireccionFiscal;
            }
        }

        public Juridico()
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

                string Comando = "INSERT INTO juridico (cl_rif, ju_denominacion_comercial, ju_razon_social, ju_capital, ju_pagina_web, lugar_lu_codigo, lugar_lu_codigo1) " +
                    "VALUES (@rif, @denominacion, @razon, @capital, @pagina, @fisica, @fiscal)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", RIF);
                Script.Parameters.AddWithValue("denominacion", DenominacionComercial);
                Script.Parameters.AddWithValue("razon", RazonSocial);
                Script.Parameters.AddWithValue("capital", Capital);
                Script.Parameters.AddWithValue("pagina", PaginaWeb);
                Script.Parameters.AddWithValue("fisica", DireccionFisica);
                Script.Parameters.AddWithValue("fiscal", DireccionFiscal);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                try
                {
                    Conexion.Close();
                }
                finally { }
            }
        }

        public Juridico LeerJuridico(string rif)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM juridico WHERE cl_rif = @rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", rif);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    Juridico juridico = new Juridico(ReadString(0), ReadString(1), ReadString(2), ReadFloat(3), ReadString(4),
                        ReadInt(5), ReadInt(6));
                    Cliente cliente = new Cliente(juridico.RIF);
                    juridico.Base(cliente);
                    return juridico;
                }
            }
            finally
            {
                try
                {
                    Conexion.Close();
                }
                finally { }
            }

            return null;
        }

        public List<Juridico> TodosJuridicos()
        {
            List<Juridico> lista = new List<Juridico>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM juridico";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Juridico juridico = new Juridico(ReadString(0), ReadString(1), ReadString(2), ReadFloat(3),
                        ReadString(4), ReadInt(5), ReadInt(6));
                    lista.Add(juridico);
                }
            }
            finally
            {
                try
                {
                    Conexion.Close();
                }
                finally
                {
                    foreach (Juridico juridico in lista)
                    {
                        Cliente cliente = new Cliente(juridico.RIF);
                        juridico.Base(cliente);
                    }
                }
            }

            return lista;
        }

        public override void Actualizar()
        {
            try
            {
                base.Actualizar();

                Conexion.Open();

                string Comando = "UPDATE juridico SET ju_denominacion_comercial = @denominacion, ju_razon_social = @razon, ju_capital = @capital, " +
                    "ju_pagina_web = @web, lugar_lu_codigo = @fisica, lugar_lu_codigo1 = @fiscal " +
                    "WHERE cl_rif = @rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", RIF);
                Script.Parameters.AddWithValue("denominacion", DenominacionComercial);
                Script.Parameters.AddWithValue("razon", RazonSocial);
                Script.Parameters.AddWithValue("capital", Capital);
                Script.Parameters.AddWithValue("web", PaginaWeb);
                Script.Parameters.AddWithValue("fisica", DireccionFisica);
                Script.Parameters.AddWithValue("fiscal", DireccionFiscal);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            finally
            {
                try
                {
                    Conexion.Close();
                }
                finally { }
            }
        }

        public override void Eliminar()
        {
            try
            {
                Conexion.Open();

                string Commando = "DELETE FROM juridico WHERE cl_rif = @rif";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("rif", RIF);

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
                base.Eliminar();
            }
        }
        #endregion

        #region Metodos Privados
        private void Base(Cliente cliente)
        {
            RIF = cliente.RIF;
            Password = cliente.Password;
            CodigoCorreoElectronico = cliente.CodigoCorreoElectronico;
            CodigoTienda = cliente.CodigoTienda;
        }
        #endregion

        #region Otros Metodos
        public PersonaContacto PersonaContacto()
        {
            return new PersonaContacto(this);
        }
        #endregion
    }
}