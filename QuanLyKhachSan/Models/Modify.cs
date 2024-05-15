using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models
{
    class Modify
    {
        public Modify()
        { }

            SqlCommand sqlCommand;
            SqlDataReader dataReader;
            public List<User> Users(string query)
            {
                List<User> taiKhoans = new List<User>();

                using (SqlConnection sqlConnection = Connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        taiKhoans.Add(new User(dataReader.GetString(0), dataReader.GetString(1)));
                    }
                    sqlConnection.Close();
                }
                return taiKhoans;
            }
        
        public void Command(string query) // ktra tai khoan
        {
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
