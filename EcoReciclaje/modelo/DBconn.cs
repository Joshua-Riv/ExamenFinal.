using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EcoReciclaje.modelo
{
    public class DBconn
    {
        public static SqlConnection obtenerConexion()
        {
            string s = System.Configuration.ConfigurationManager
                .ConnectionStrings["conexion"].ConnectionString;

            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();

            return conexion;
        }
    }
}