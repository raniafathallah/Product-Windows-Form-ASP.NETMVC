using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ProductsApp.BL
{
    class CLS_ORDER
    {
        public DataTable GET_LAST_ORDER_ID()
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            DT = DAL.selectData("GET_LAST_ORDER_ID", null);
            DAL.close();
            return DT;
        }


        public void ADD_ORDER(int order_id, DateTime order_date, int customer_id, string description_order, string salesman)
        {

            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;
            param[1] = new SqlParameter("@order_date", SqlDbType.DateTime);
            param[1].Value = order_date;

            param[2] = new SqlParameter("@customer_id", SqlDbType.Int);
            param[2].Value = customer_id;

            param[3] = new SqlParameter("@description_order", SqlDbType.VarChar, 250);
            param[3].Value = description_order;

            param[4] = new SqlParameter("@salesman", SqlDbType.VarChar, 50);
            param[4].Value = salesman;

            DAL.execut_Command("ADD_ORDER", param);
            DAL.close();



        }


        public void ADD_ORDER_DETAILS(string ID_PRODUCT, int ID_ORDER, int QTE, string PRICE, float DISCOUNT,
 string AMOUNT, string TOTALAMOUNT)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            param[0].Value = ID_PRODUCT;
            param[1] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[1].Value = ID_ORDER;

            param[2] = new SqlParameter("@QTE", SqlDbType.Int);
            param[2].Value = QTE;

            param[3] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            param[3].Value = PRICE;

            param[4] = new SqlParameter("@DISCOUNT", SqlDbType.Float);
            param[4].Value = DISCOUNT;


            param[5] = new SqlParameter("@AMOUNT", SqlDbType.VarChar, 50);
            param[5].Value = AMOUNT;
            param[6] = new SqlParameter("@TOTALAMOUNT", SqlDbType.VarChar, 50);
            param[6].Value = TOTALAMOUNT;
            DAL.execut_Command("ADD_ORDER_DETAILS", param);
            DAL.close();
        }



        public DataTable verifyQty(String ID_PRODUCT,int qtn)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            param[0].Value = ID_PRODUCT;
            param[1] = new SqlParameter("@qtn", SqlDbType.VarChar, 50);
            param[1].Value = qtn;
            DT = DAL.selectData("verifyQty", param);
            DAL.close();
            return DT;

        }



        //order_details_report
        //      /*  order_details_report*/
        /*GET_LAST_ORDER_ID_print*/

        public DataTable GET_LAST_ORDER_ID_print()
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
      
            DT = DAL.selectData("GET_LAST_ORDER_ID_print", null);

            DAL.close();
            return DT;
        }
        public DataTable GET_order_details_report(int ID)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ORD_ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            DT = DAL.selectData("order_details_report", param);
            DAL.close();
            return DT;
        }


    }
}
