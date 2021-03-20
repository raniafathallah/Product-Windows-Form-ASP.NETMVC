using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProductsApp.DAL
{
    class Dataaccesslayer
    {
        SqlConnection sqlConnection;
        public Dataaccesslayer()
        {
         
            sqlConnection = new SqlConnection(@"Data Source=rania;Initial Catalog=Products_db;Integrated Security=true;");
        }
            public void open()
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
            }
            public void close()
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        //method to read data from database 
        public DataTable selectData( string stored_proc,SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_proc;
            sqlcmd.Connection = sqlConnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

        public void execut_Command(string stored_proc,SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_proc;
            sqlcmd.Connection = sqlConnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }

    }
}
