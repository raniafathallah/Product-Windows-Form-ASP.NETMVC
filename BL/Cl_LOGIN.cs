using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProductsApp.BL
{
    class Cl_LOGIN
    {

        public DataTable LOGIN(string ID,string PSW)
        {

         
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            param[1] = new SqlParameter("@PSW", SqlDbType.VarChar, 50);
            param[1].Value = PSW;

            DAL.open();
            DataTable DT = new DataTable();
            DT = DAL.selectData("SP_LOGIN", param);
     //       Program.SalesMan = DT.Rows[0]["FULLNAME"].ToString();
            DAL.close();
            return DT;
        }



        public void Add_User( string ID,string PSW, string USERTYPE, string FULLNAME)
        {

            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            param[1] = new SqlParameter("@PSW", SqlDbType.VarChar, 50);
            param[1].Value = PSW;

            param[2] = new SqlParameter("@USERTYPE", SqlDbType.NChar, 50);
            param[2].Value = USERTYPE;

            param[3] = new SqlParameter("@FULLNAME", SqlDbType.VarChar, 250);
            param[3].Value = FULLNAME;
    

            DAL.execut_Command("Add_User", param);
            DAL.close();
        }


        public void Edit_User(string ID, string PSW, string USERTYPE, string FULLNAME)
        {

            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            param[1] = new SqlParameter("@PSW", SqlDbType.VarChar, 50);
            param[1].Value = PSW;

            param[2] = new SqlParameter("@USERTYPE", SqlDbType.NChar, 50);
            param[2].Value = USERTYPE;

            param[3] = new SqlParameter("@FULLNAME", SqlDbType.VarChar, 50);
            param[3].Value = FULLNAME;


            DAL.execut_Command("Edit_User", param);
            DAL.close();
        }


   



        public void Delete_User(string ID)
        {

            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar,50);
            param[0].Value = ID;
            DAL.execut_Command("Delete_User ", param);
            DAL.close();
        }
 
        public DataTable Search_User(string criterion)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@criterion", SqlDbType.VarChar);
            param[0].Value = criterion;
            DT = DAL.selectData("Search_User", param);
            DAL.close();
            return DT;
        }

        public DataTable Get_All_Users()
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
         
            DT = DAL.selectData("Get_All_Users", null);
            DAL.close();
            return DT;
        }

    }
}
