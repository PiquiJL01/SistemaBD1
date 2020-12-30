using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace Ucabmart.Command
{
    public class ConexionBD
    {
        

        NpgsqlConnection conexion = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = 1234; Database = postgres");
        
        public void conectar()
        {
           // conexion.ConnectionString = "Server = localhost; User Id = postgres; Password = 1234; Database = postgres";
            conexion.Open();
            

        }

    }
}