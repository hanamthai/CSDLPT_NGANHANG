using System.Data.SqlClient;
using System.Data;
using System;
using System.Diagnostics;
using System.Configuration;

namespace NGANHANG.Lib
{
    public class DbConnection
    {
        private static string defaultConnectionString;

        public static void SetDefaultConnectionString(string connectionString)
        {
            defaultConnectionString = connectionString;
        }

        public static string GetDefaultConnectionString()
        {
            return defaultConnectionString;
        }

        public static int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(defaultConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    // Debug
                    Debug.WriteLine(cmd.CommandText);

                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuery(string commandText, string connectionString, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuery(string commandText, SqlConnection conn, CommandType commandType, params SqlParameter[] parameters)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                }

                return cmd.ExecuteNonQuery();
            }
        }

        public static Object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(defaultConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    // Debug
                    Debug.WriteLine(cmd.CommandText);

                    try
                    {
                        conn.Open();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }

        public static Object ExecuteScalar(string commandText, SqlConnection conn, CommandType commandType, params SqlParameter[] parameters)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                }

                return cmd.ExecuteScalar();
            }
        }

        public static SqlDataReader ExecuteReader(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(defaultConnectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                // Debug
                Debug.WriteLine(cmd.CommandText);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                }

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

        public static SqlDataReader ExecuteReader(string commandText, string connectionString, CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                }

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

        public static SqlDataReader ExecuteReader(string commandText, SqlConnection conn, CommandType commandType, params SqlParameter[] parameters)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                }

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

        public static DataTable ExecuteAdapter(string commandText, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(defaultConnectionString);

            using (SqlDataAdapter da = new SqlDataAdapter(commandText, conn))
            {
                da.SelectCommand.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                }
                catch
                {
                    throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                }

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public static DataTable ExecuteAdapter(string commandText, string connectionString, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlDataAdapter da = new SqlDataAdapter(commandText, conn))
            {
                da.SelectCommand.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                }
                catch
                {
                    throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                }

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        public static DataTable ExecuteAdapter(string commandText, SqlConnection conn, params SqlParameter[] parameters)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            using (SqlDataAdapter da = new SqlDataAdapter(commandText, conn))
            {
                da.SelectCommand.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                }
                catch
                {
                    throw new Exception("Không thể kết nối tới cơ sở dữ liệu!");
                }

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}
