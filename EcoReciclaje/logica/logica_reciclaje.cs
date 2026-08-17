using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EcoReciclaje.modelo;

namespace EcoReciclaje.logica
{
    public class logica_reciclaje
    {
        public static List<cls_reciclaje> reciclajes = new List<cls_reciclaje>();

        public static List<cls_reciclaje> ObtenerReciclajes()
        {
            reciclajes.Clear();

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_listareciclaje", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cls_reciclaje reciclaje = new cls_reciclaje();

                            reciclaje.id = reader.GetInt32(0);
                            reciclaje.usuario = reader.GetInt32(1);
                            reciclaje.nombreUsuario = reader.GetString(2);
                            reciclaje.tipo = reader.GetInt32(3);
                            reciclaje.nombreTipo = reader.GetString(4);
                            reciclaje.cantidad = reader.GetDecimal(5);
                            reciclaje.fecha = reader.GetDateTime(6);

                            reciclajes.Add(reciclaje);
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return reciclajes;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return reciclajes;
        }

        public static int AgregarReciclaje(
            int usuario,
            int tipo,
            decimal cantidad,
            DateTime fecha)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_agregarreciclaje", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID_USUARIO", usuario));
                    cmd.Parameters.Add(new SqlParameter("@ID_TIPO", tipo));
                    cmd.Parameters.Add(new SqlParameter("@CANTIDAD", cantidad));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", fecha));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }

        public static int ActualizarReciclaje(
            int id,
            int usuario,
            int tipo,
            decimal cantidad,
            DateTime fecha)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_actualizarreciclaje", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    cmd.Parameters.Add(new SqlParameter("@ID_USUARIO", usuario));
                    cmd.Parameters.Add(new SqlParameter("@ID_TIPO", tipo));
                    cmd.Parameters.Add(new SqlParameter("@CANTIDAD", cantidad));
                    cmd.Parameters.Add(new SqlParameter("@FECHA", fecha));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }

        public static int BorrarReciclaje(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_borrarreciclaje", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }

        public static DataTable ObtenerEstadistica()
        {
            DataTable tabla = new DataTable();

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_estadisticareciclaje", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return tabla;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return tabla;
        }
    }
}