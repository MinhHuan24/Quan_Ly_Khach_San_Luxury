using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    class LoginCtrl
    {
        public static string checkDangNhap(string _user, string _pass)
        {
            try
            {
                string query = "SELECT * FROM DangNhap WHERE IdDangNhap = @IdDangNhap AND MatKhau = @MatKhau";
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@IdDangNhap", _user),
                    new SqlParameter("@MatKhau", _pass)
                };
                return Models.Connection.ExecuteQuery(query, sqlParameters).Rows.Count > 0 ? _user : "";
            }
            catch
            {
                return "";
            }
        }
    }
}
