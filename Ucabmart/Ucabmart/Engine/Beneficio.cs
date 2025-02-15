﻿using Npgsql;
using System;
using System.Collections.Generic;

namespace Ucabmart.Engine
{
    public class Beneficio : ConexionBD<Beneficio, int>
    {
        #region Atributos
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Declaraciones
        public Beneficio(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        private Beneficio(int codigo, string nombre, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Beneficio(int codigo)
        {
            if (!(codigo == 0))
            {
                Beneficio beneficio = Leer(codigo);
                if (!(beneficio == null))
                {
                    Codigo = beneficio.Codigo;
                    Nombre = beneficio.Nombre;
                    Descripcion = beneficio.Descripcion;
                }
                else
                {
                    Codigo = 0;
                    Nombre = null;
                    Descripcion = null;
                }
            }
        }

        public Beneficio()
        {
        }
        #endregion

        #region CRUDs
        public override void Insertar()
        {
            try
            {
                Conexion.Open();

                string Comando = "INSERT INTO beneficio (be_nombre, be_descripcion) VALUES (@nombre, @descripcion) RETURNING be_codigo";
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

        public override Beneficio Leer(int codigo)
        {
            try
            {
                Conexion.Open();

                string Comando = "SELECT * FROM beneficio WHERE be_codigo=@codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", codigo);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    return new Beneficio(ReadInt(0), ReadString(1), ReadString(2));
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

            return null;
        }

        public override List<Beneficio> Todos()
        {
            List<Beneficio> lista = new List<Beneficio>();

            try
            {
                Conexion.Open();

                string Command = "SELECT * FROM beneficio";
                NpgsqlCommand Script = new NpgsqlCommand(Command, Conexion);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Beneficio beneficio = new Beneficio(ReadInt(0), ReadString(1), ReadString(2));

                    lista.Add(beneficio);
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

                string Comando = "UPDATE beneficio SET be_nombre = @nombre, be_descripcion = @descripcion WHERE be_codigo = @codigo";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

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

                string Commando = "DELETE FROM beneficio WHERE be_codigo = @codigo";
                Script = new NpgsqlCommand(Commando, Conexion);

                Script.Parameters.AddWithValue("codigo", Codigo);

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
        #endregion

        #region OtrosMetodos
        public List<int> BeneficiosCod(List<String> items)
        {
            Beneficio p1 = new Beneficio();

            List<Beneficio> beneficios = new List<Beneficio>();
            beneficios = p1.Todos();
            List<int> lista = new List<int>();

            foreach (Beneficio beneficio in beneficios)
            {
                if (items.Contains(beneficio.Nombre))
                {
                    lista.Add(beneficio.Codigo);
                }
            }

            return lista;

        }
        #endregion

        #region retorna los codigos de los beneficios del empleado
        public List<int> codigoBeneficios(int codigoEmpleado)
        {
            List<int> listaBeneficios = new List<int>();

            try
            {
                Conexion.Open();

                string Comando = "SELECT beneficio_be_codigo FROM em_be WHERE empleado_em_codigo=@codigoEmpleado";
                Script = new NpgsqlCommand(Comando, Conexion);

                Script.Parameters.AddWithValue("codigoEmpleado", codigoEmpleado);
                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    listaBeneficios.Add(ReadInt(0));
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
            return listaBeneficios;
        }
        #endregion
    }
}