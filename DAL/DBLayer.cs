using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBLayer
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter adp = null;

        string connStr = @"Data Source = (local) ;Initial Catalog = QuanLyBanHoa ;Integrated Security = true";
        public DBLayer()
        {
            conn = new SqlConnection(connStr);
            cmd = conn.CreateCommand();
        }

        public DataSet GetData(string sqlStr)
        {
            cmd.CommandText = sqlStr;
            cmd.CommandType = CommandType.Text;

            adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                adp.Fill(ds);

            }
            catch { }
          
            return ds;
        }
        public bool ExecuteNonQuery(ref string err, string sqlStr, CommandType ct, params SqlParameter[] ps)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();

            cmd.CommandText = sqlStr;
            cmd.CommandType = ct;

            cmd.Parameters.Clear();
            foreach (var p in ps)
            {
                cmd.Parameters.Add(p);
            }

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(SqlException ex)
            {
                err = "Không thực hiện truy vấn được. Lỗi: "+ ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public int LoginHandle(string commandText, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.Open();

            cmd.CommandText = commandText;
            cmd.CommandType = ct;

            int result = (int)cmd.ExecuteScalar();
            return result;
        }
    }
}
