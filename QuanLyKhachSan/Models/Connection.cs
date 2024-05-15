using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKhachSan.Models
{
    class Connection
    {
        private static string connectionString = @"Data Source=DESKTOP-5TIU7BH;Initial Catalog=QL_KSan;Integrated Security=True;Encrypt=True;";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetSqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
