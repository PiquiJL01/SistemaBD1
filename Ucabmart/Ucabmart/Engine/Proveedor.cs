using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Proveedor : ConexionBD<Proveedor, string>
    {
        #region Atributos
        public string RIF { get; set; }
        public string RazonSocial { get; set; }
        public string DenominacionComercial { get; set; }
        public string PaginaWeb { get; set; }
        public int DireccionFisica { get; set; }
        public int DireccionFiscal { get; set; }
        public int CodigoCorreoElectronico { get; set; }
        #endregion

        #region Declaraciones
        public Proveedor(string rif, string razonSocial, string denominacionComercial, string paginaWeb,
            Lugar direccionFisica, Lugar direccionFiscal, CorreoElectronico correoElectronico)
        {
            RIF = rif;
            RazonSocial = razonSocial;
            DenominacionComercial = denominacionComercial;
            PaginaWeb = paginaWeb;
            DireccionFisica = direccionFisica.Codigo;
            DireccionFiscal = direccionFiscal.Codigo;
            CodigoCorreoElectronico = correoElectronico.Codigo;
        }

        public Proveedor(string rif, string razonSocial, string denominacionComercial, string paginaWeb,
            int direccionFisica, int direccionFiscal, int correo)
        {
            RIF = rif;
            RazonSocial = razonSocial;
            DenominacionComercial = denominacionComercial;
            PaginaWeb = paginaWeb;
            DireccionFisica = direccionFisica;
            DireccionFiscal = direccionFiscal;
            CodigoCorreoElectronico = correo;
        }

        public Proveedor(string rif)
        {
            Proveedor proveedor = Leer(rif);
            if (!(proveedor == null))
            {
                RIF = proveedor.RIF;
                RazonSocial = proveedor.RazonSocial;
                DenominacionComercial = proveedor.DenominacionComercial;
                RazonSocial = proveedor.RazonSocial;
                DireccionFisica = proveedor.DireccionFisica;
                DireccionFiscal = proveedor.DireccionFiscal;
                CodigoCorreoElectronico = proveedor.CodigoCorreoElectronico;
            }
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO proveedor (pr_rif, pr_razon_social, pr_denominacion_social, pr_pag_web, Lugar_lu_codigo, lugar_lu_codigo1, correo_electronico_ce_codigo) " +
                    "VALUES (@rif, @razon, @denominacion, @web, @fisica, @fiscal, @correo)";
                
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", RIF);
                Script.Parameters.AddWithValue("razon", RazonSocial);
                Script.Parameters.AddWithValue("denominacion", DenominacionComercial);
                Script.Parameters.AddWithValue("web", PaginaWeb);
                Script.Parameters.AddWithValue("fisica", DireccionFisica);
                Script.Parameters.AddWithValue("fiscal", DireccionFiscal);
                Script.Parameters.AddWithValue("correo", CodigoCorreoElectronico);

                Script.Prepare();

                Script.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }

        public override Proveedor Leer(string rif)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM proveedor WHERE pr_rif = @rif";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", rif);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Proveedor(ReadString(0), ReadString(1), ReadString(2), ReadString(3), ReadInt(4), ReadInt(5),ReadInt(6));
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

        public override List<Proveedor> Todos()
        {
            List<Proveedor> lista = new List<Proveedor>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM proveedor";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Proveedor proveedor = new Proveedor(ReadString(0), ReadString(1), ReadString(2), ReadString(3), ReadInt(4), ReadInt(5), ReadInt(6));

                    lista.Add(proveedor);
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

                string Comando = "UPDATE proveedor SET pr_razon_social = @razon, pr_denominacion_social = @denominacion, " +
                    "pr_pag_web = @web, Lugar_lu_codigo = @fisica, lugar_lu_codigo1 = @fiscal, correo_electronico_ce_codigo = @correo " +
                    "WHERE pr_rif = @rif ";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("rif", RIF);
                Script.Parameters.AddWithValue("razon", RazonSocial);
                Script.Parameters.AddWithValue("denominacion", DenominacionComercial);
                Script.Parameters.AddWithValue("web", PaginaWeb);
                Script.Parameters.AddWithValue("fisica", DireccionFisica);
                Script.Parameters.AddWithValue("fiscal", DireccionFiscal);
                Script.Parameters.AddWithValue("correo", CodigoCorreoElectronico);

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

                string Commando = "DELETE FROM proveedor WHERE pr_rif = @rif";
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