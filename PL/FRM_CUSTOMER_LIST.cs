using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsApp.PL
{
    public partial class FRM_CUSTOMER_LIST : Form
    {
        public FRM_CUSTOMER_LIST()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = Get_All_Customers();
      
        }
        public FRM_CUSTOMER_LIST(string pro)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = Get_Products();
            this.Text = "لائحه المنتجات ";
        }


        public DataTable Get_All_Customers()
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            DT = DAL.selectData("Get_All_Customers", null);
            DAL.close();
            return DT;
        }

        public DataTable Get_Products()
        {
            DAL.Dataaccesslayer DAL = new DAL.Dataaccesslayer();
            DataTable DT = new DataTable();
            DT = DAL.selectData("Get_Products", null);
            DAL.close();
            return DT;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

           this.Close();
        }
    }
}
