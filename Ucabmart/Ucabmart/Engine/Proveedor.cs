﻿using Npgsql;
using System;
using System.Collections.Generic;

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
                PaginaWeb = proveedor.PaginaWeb;
            }
        }
        public Proveedor()
        {
        }

        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO proveedor (pr_rif, pr_razon_social, pr_denominacion_comercial, pr_pag_web, Lugar_lu_codigo, lugar_lu_codigo2, correo_electronico_ce_codigo) " +
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
                    return new Proveedor(ReadString(0), ReadString(1), ReadString(2), ReadString(3), ReadInt(4), ReadInt(5), ReadInt(6));
                }

                Conexion.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                Conexion.Close();
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
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                Conexion.Close();
            }

            return lista;
        }

        public override void Actualizar()
        {
            try
            {
                Conexion.Open();

                string Comando = "UPDATE proveedor SET pr_razon_social = @razon, pr_denominacion_comercial = @denominacion, " +
                    "pr_pag_web = @web, lugar_lu_codigo = @fisica, lugar_lu_codigo2 = @fiscal, correo_electronico_ce_codigo = @correo " +
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
                Conexion.Close();                
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
                throw new Exception("Ha ocurrido un error en la base de datos", e);
            }
            finally
            {
                Conexion.Close();
            }
        }
        #endregion

        #region Metodos Entidades Muchos-A-Muchos
        public void AgregarProducto(Producto producto)
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO pr_pr (producto_pr_codigo, proveedor_pr_rif) " +
                    "VALUES (@producto, @proveedor)";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("producto", producto.Codigo);
                Script.Parameters.AddWithValue("proveedor", RIF);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }

        public void EliminarProducto(Producto producto)
        {
            try
            {
                Conexion.Open();

                string Comando = "DELETE FROM pr_pr " +
                    "WHERE ((producto_pr_codigo = @producto) AND (proveedor_pr_rif = @proveedor))";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("producto", producto.Codigo);
                Script.Parameters.AddWithValue("proveedor", RIF);

                Script.Prepare();

                Script.ExecuteNonQuery();

                Conexion.Close();
            }
            catch (Exception e)
            {
                Conexion.Close();
            }
        }
        //obtiene la lista de los codigos de la tabla PR_PR dado un numero de rif del proveedor asociado
        public  List<int> TodosEnPP_PR(string rif)
        {
            List<int> listaPR_PR = new List<int>();
            int codigoProd = 0;

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM pr_pr";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                
                while (Reader.Read())
                {
                    if (rif == ReadString(1))
                    {
                        codigoProd = (ReadInt(0));
                        listaPR_PR.Add(codigoProd);
                    }
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

            return listaPR_PR;
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