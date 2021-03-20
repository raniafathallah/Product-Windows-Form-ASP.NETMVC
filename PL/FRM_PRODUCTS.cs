using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
///*using System.Drawing;*/
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;

namespace ProductsApp.PL
{
    public partial class FRM_PRODUCTS : Form
    {

            private static FRM_PRODUCTS frm2;
            static void frm_formclosed(object sender, FormClosedEventArgs e)
            {
                frm2 = null;
            }
            public static FRM_PRODUCTS get_main_form
            {
                get
                {
                    if (frm2 == null)
                    {
                        frm2 = new FRM_PRODUCTS();
                        frm2.FormClosed += new FormClosedEventHandler(frm_formclosed);
                    }
                    return frm2;
                }
            }
            BL.cls_products prd = new BL.cls_products();

        public FRM_PRODUCTS()
        {
            InitializeComponent();
            if (frm2 == null)
            {
                frm2 = this; 
            }
            this.dataGridView1.DataSource = prd.Get_All_Products();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /* print event */
            //  Get_Single_Product
            Reporting.CrystalReport1 report = new Reporting.CrystalReport1();
            report.SetParameterValue("@ID", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Reporting.FRM_RPT_PRODUCT myfrm = new Reporting.FRM_RPT_PRODUCT();
            myfrm.crystalReportViewer1.ReportSource = report;
            myfrm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            DT = prd.search_product(textBox1.Text);
            this.dataGridView1.DataSource = DT;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد حقا حذف المنتج", "عمليه الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                prd.Delete_Product(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                this.dataGridView1.DataSource = prd.Get_All_Products();
                MessageBox.Show("تمت عمليه الحذف بنجاح", "عمليه الحذف", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("لم يتم الحذف", "عمليه الحذف", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.id_product.Text =this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.des_prod.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.quant_prod.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.price_product.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.img_product.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            /*   frm.id_product.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();*/
            frm.Text = "تعديل منتج";
            frm.state = "update";
            frm.id_product.ReadOnly = true;

            /*        FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();*/
            try
            {
                byte[] ima = (byte[])prd.Get_Image_Product(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];

                MemoryStream ms = new MemoryStream(ima);
                frm.img_product.Image = System.Drawing.Image.FromStream(ms); ;

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);

            }
     

            frm.ShowDialog();



        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FRM_PREVIEW frm = new FRM_PREVIEW();

            try
            {
                DataTable dtt = new DataTable();
                dtt = prd.Get_Image_Product(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                byte[] ima = (byte[])dtt.Rows[0][0];
             //   MemoryStream ms = new MemoryStream(ima);
              //  frm.pictureBox1.Image = ima.FromStream(ms); ;
                frm.pictureBox1.Image = ByteToImage(ima);

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            frm.ShowDialog();
       
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Reporting.CrystalReport2 report = new Reporting.CrystalReport2();
       
            Reporting.FRM_RPT_PRODUCT myfrm = new Reporting.FRM_RPT_PRODUCT();
            myfrm.crystalReportViewer1.ReportSource = report;
            myfrm.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Reporting.CrystalReport2 report2 = new Reporting.CrystalReport2();
            ////
            ExportOptions export = new ExportOptions();
            ExcelFormatOptions excelformat = new ExcelFormatOptions();
            DiskFileDestinationOptions dfoption = new DiskFileDestinationOptions();
            ////
            export = report2.ExportOptions;
            dfoption.DiskFileName = @"Desktop:\productList.xls";
            export.ExportFormatType = ExportFormatType.Excel;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            export.ExportFormatOptions = excelformat;
            report2.ExportToDisk(ExportFormatType.Excel,"E:\\productList.xls");
            MessageBox.Show("list export successfully", "export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
