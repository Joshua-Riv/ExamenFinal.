using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EcoReciclaje.modelo;

namespace EcoReciclaje.logica
{
    public class logica_usuario
    {
        public static List<cls_usuario> usuarios = new List<cls_usuario>();

        public static List<cls_usuario> ObtenerUsuarios()
        {
            usuarios.Clear();

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_listausuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cls_usuario usuario = new cls_usuario();

                            usuario.id = reader.GetInt32(0);

                            if (!reader.IsDBNull(1))
                                usuario.cedula = reader.GetString(1);
                            else
                                usuario.cedula = "";

                            if (!reader.IsDBNull(2))
                                usuario.nombre = reader.GetString(2);
                            else
                                usuario.nombre = "";

                            if (!reader.IsDBNull(3))
                                usuario.correo = reader.GetString(3);
                            else
                                usuario.correo = "";

                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return usuarios;
        }

        public static int AgregarUsuario(string cedula, string nombre, string correo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_agregarusuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@CEDULA", cedula));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", correo));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
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

        public static int ActualizarUsuario(int id, string cedula, string nombre, string correo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_actualizarusuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    cmd.Parameters.Add(new SqlParameter("@CEDULA", cedula));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", correo));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
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

        public static int BorrarUsuario(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_borrarusuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
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
        public static int BorrarReciclajesUsuario(int idUsuario)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_borrarreciclajesusuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@ID_USUARIO", idUsuario));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
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
    }
}