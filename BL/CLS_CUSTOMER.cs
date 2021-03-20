using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ProductsApp.BL
{
    class CLS_CUSTOMER
    {


        public void ADD_Customer(string firstName, string lirstName, string tel,
             string Email, byte[] img,string criterion)
        {

            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@firstName", SqlDbType.VarChar, 25);
            param[0].Value = firstName;
            param[1] = new SqlParameter("@lirstName", SqlDbType.VarChar, 25);
            param[1].Value = lirstName;

            param[2] = new SqlParameter("@tel", SqlDbType.NChar, 10);
            param[2].Value = tel;

            param[3] = new SqlParameter("@Email", SqlDbType.VarChar, 15);
            param[3].Value = Email;
            param[4] = new SqlParameter("@picture", SqlDbType.Image);
            param[4].Value = img;
            param[5] = new SqlParameter("@criterion", SqlDbType.VarChar,50);
            param[5].Value = criterion;
            
            DAL.execut_Command("ADD_Customer", param);
            DAL.close();

        
        
        }



        public void EDIT_Customer(string firstName, string lirstName, string tel,
       string Email, byte[] img, string criterion,int ID)
        {

            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@firstName", SqlDbType.VarChar, 25);
            param[0].Value = firstName;
            param[1] = new SqlParameter("@lirstName", SqlDbType.VarChar, 25);
            param[1].Value = lirstName;

            param[2] = new SqlParameter("@tel", SqlDbType.NChar, 10);
            param[2].Value = tel;

            param[3] = new SqlParameter("@Email", SqlDbType.VarChar, 15);
            param[3].Value = Email;
            param[4] = new SqlParameter("@picture", SqlDbType.Image);
            param[4].Value = img;
            param[5] = new SqlParameter("@criterion", SqlDbType.VarChar, 50);
            param[5].Value = criterion;
            param[6] = new SqlParameter("@ID", SqlDbType.Int);
            param[6].Value = ID;
            DAL.execut_Command("EDIT_Customer", param);
            DAL.close();
        }

      

        public void DELETE_Customer(int ID)
        {

            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DAL.execut_Command("DELETE_Customer", param);
            DAL.close();
        }
        public DataTable Get_All_Customers()
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            DT = DAL.selectData("Get_All_Customers", null);
            DAL.close();
            return DT;
        }

        public DataTable SEARCH_Customer(string criterion)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@criterion", SqlDbType.VarChar);
            param[0].Value = criterion;
            DT = DAL.selectData("SEARCH_Customer", param);
            DAL.close();
            return DT;
        }
    }
}
