using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProductsApp.BL
{
    class cls_products
    {
        public DataTable Get_All_Categories()
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            DT = DAL.selectData("Get_Categories", null);
            DAL.close();
            return DT;
        }
        //,byte[] imgAdd_Product
        public void Add_Product(int cat_id, string label, string product_id,
            int qtn,string price,byte[] img)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];
        

            param[0] = new SqlParameter("@id_cat",SqlDbType.Int);
            param[0].Value = cat_id;
            param[1] = new SqlParameter("@label", SqlDbType.VarChar,10);
            param[1].Value = label;

            param[2] = new SqlParameter("@product_id", SqlDbType.VarChar,30);
            param[2].Value = product_id;
 
            param[3] = new SqlParameter("@qte", SqlDbType.Int);
            param[3].Value = qtn;

            param[4] = new SqlParameter("@price", SqlDbType.VarChar,50);
            param[4].Value = price;
            param[5] = new SqlParameter("@img", SqlDbType.Image);
            param[5].Value = img;


            DAL.execut_Command("Add_Product",param);
            DAL.close();

        }
       
        
        //UPDATE PRODUCT 

        public void Update_Product (int cat_id, string label, string product_id,
 int qtn, string price, byte[] img)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];


            param[0] = new SqlParameter("@id_cat", SqlDbType.Int);
            param[0].Value = cat_id;
            param[1] = new SqlParameter("@label", SqlDbType.VarChar, 10);
            param[1].Value = label;

            param[2] = new SqlParameter("@product_id", SqlDbType.VarChar, 30);
            param[2].Value = product_id;

            param[3] = new SqlParameter("@qte", SqlDbType.Int);
            param[3].Value = qtn;

            param[4] = new SqlParameter("@price", SqlDbType.VarChar, 50);
            param[4].Value = price;
            param[5] = new SqlParameter("@img", SqlDbType.Image);
            param[5].Value = img;
            DAL.execut_Command("Update_Product", param);
            DAL.close();

        }


        //verifyProductID
        public DataTable verifyProductID( String ID)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            DT = DAL.selectData("verifyProductID", param);
            DAL.close();
            return DT;

        }
        public DataTable Get_All_Products()
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            DT = DAL.selectData("Get_All_Products", null);
            DAL.close();
            return DT;
        }

        public DataTable search_product(String ID)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            DT = DAL.selectData("search_product", param);
            DAL.close();
            return DT;

        }




        public void Delete_Product(String ID)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DAL.open();
            DataTable DT = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = int.Parse(ID);
             DAL.execut_Command("Delete_Product", param);
            DAL.close();
            
        }

      

        public DataTable Get_Image_Product(String ID)
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = int.Parse(ID);
            DT = DAL.selectData("Get_Image_Product", param);
            DAL.close();
            return DT;

        }
    }
}
