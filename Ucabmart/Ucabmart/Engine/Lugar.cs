using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
    public class Lugar : DBConnection<Lugar, int>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int CodigoUbicacion { get; set; }

        public Lugar(int codigo, string nombre, TipoLugar tipo, string descripcion, Lugar ubicacion = null)
        {
            Codigo = codigo;
            Nombre = nombre;
            switch (tipo)
            {
                case TipoLugar.Direccion:
                    Tipo = "Dirección";
                    break;
                case TipoLugar.Estado:  
                    Tipo = "Estado";
                    break;
                case TipoLugar.Municipio:
                    Tipo = "Municipio";
                    break;
                case TipoLugar.Pais:
                    Tipo = "País";
                    break;
                case TipoLugar.Parroquia:
                    Tipo = "Parroquia";
                    break;
                default:
                    Tipo = null;
                    break;
            }
            Descripcion = descripcion;
            if (ubicacion == null)
            {
                CodigoUbicacion = 0;
            }
            else
            {
                CodigoUbicacion = ubicacion.Codigo;
            }
        }

        public override NpgsqlCommand ScriptInsertar()
        {
            NpgsqlCommand Script;
            if (CodigoUbicacion == 0)
            {
                string Comando = "INSERT INTO lugar (lu_codigo, lu_nombre, lu_tipo, lu_descripcion) VALUES (@codigo, @nombre, @tipo, @descripcion)";
                Script = new NpgsqlCommand(Comando, Connection);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("tipo", Tipo);
                Script.Parameters.AddWithValue("descripcion", Descripcion);
            }
            else
            {
                string Command = "INSERT INTO lugar (lu_codigo, lu_nombre, lu_tipo, lu_descripcion, lugar_lu_codigo) VALUES (@codigo, @nombre, @tipo, @descripcion, @lugar)";
                Script = new NpgsqlCommand(Command, Connection);

                Script.Parameters.AddWithValue("codigo", Codigo);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("tipo", Tipo);
                Script.Parameters.AddWithValue("descripcion", Descripcion);
                Script.Parameters.AddWithValue("lugar", CodigoUbicacion);
            }

            return Script;
        }

        public override Lugar Leer(int codigo)
        {
            throw new NotImplementedException();
        }
    }
}