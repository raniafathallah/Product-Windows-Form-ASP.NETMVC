using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ProductsApp.BL
{
    class Category
    {


        public DataTable Checkidexists(int ID)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID",SqlDbType.Int);
            param[0].Value = ID;
            DT = DAL.selectData("verifyCategoryID", param);
            DAL.close();
            return DT;

        }
    }
}
