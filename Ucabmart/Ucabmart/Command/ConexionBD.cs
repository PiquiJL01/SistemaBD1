using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace Ucabmart.Command
{
    public class ConexionBD
    {      
        public TaskEventHandler Conectar()
        {
            var connectionString = "Host = localhost; User Id = postgres; Password = 1234; Database = postgres";
            
            var conexion = new NpgsqlConnection(connectionString);

            // conexion.ConnectionString = "Server = localhost; User Id = postgres; Password = 1234; Database = postgres";
            conexion.Open();

            return null;
        }

    }
}