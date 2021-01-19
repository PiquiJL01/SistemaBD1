using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }

        public Juridico LeerJuridico(string rif)
        {
            string clave = null;
            string denominacionComercial = null;
            string razonSocial = null;
            float  capital = 0;
            string paginaWeb = null;
            int direccionFisica = 0;
            int direccionFiscal = 0;
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM juridico WHERE cl_rif = @rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", rif);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    clave = ReadString(0);
                    denominacionComercial = ReadString(1);
                    razonSocial = ReadString(2);
                    capital = ReadFloat(3);
                    paginaWeb = ReadString(4);
                    direccionFisica= ReadInt(5);
                    direccionFiscal = ReadInt(6);
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

            Juridico juridico = new Juridico(clave, denominacionComercial, razonSocial, capital, paginaWeb, direccionFisica, direccionFiscal);
            return juridico;
        }

        public List<Juridico> TodosJuridicos()
        {
            string clave = null;
            string denominacionComercial = null;
            string razonSocial = null;
            float capital = 0;
            string paginaWeb = null;
            int direccionFisica = 0;
            int direccionFiscal = 0;

            List<Juridico> listaJuridico = new List<Juridico>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM juridico";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();
                
                while (Reader.Read())
                {
                    clave = ReadString(0);
                    denominacionComercial = ReadString(1);
                    razonSocial = ReadString(2);
                    capital = ReadFloat(3);
                    paginaWeb = ReadString(4);
                    direccionFisica = ReadInt(5);
                    direccionFiscal = ReadInt(6);
                    Juridico juridico = new Juridico(clave, denominacionComercial, razonSocial, capital, paginaWeb, direccionFisica, direccionFiscal);
                    listaJuridico.Add(juridico);
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

            return listaJuridico;
        }

        public override void Actualizar()
        {
            try
            {
                base.Actualizar();

                Conexion.Open();

                string Comando = "UPDATE tabla SET ju_denominacion_social = @denominacion, ju_razon_social = @razon, ju_capital = @capital, " +
                    "ju_pagina_web = @web, ju_lugar_codigo = @fisica, ju_lugar_codigo1 = @fiscal " +
                    "WHERE cl_rif = @rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", RIF);
                Script.Parameters.AddWithValue("denominacion", DenominacionComercial);
                Script.Parameters.AddWithValue("razon", RazonSocial);
                Script.Parameters.AddWithValue("capital", Capital);
                Script.Parameters.AddWithValue("web", PaginaWeb);
                Script.Parameters.AddWithValue("fisica", DireccionFisica);
                Script.Parameters.AddWithValue("Fiscal", DireccionFiscal);

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

                string Commando = "DELETE FROM juridico WHERE cl_rif = @rif";
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