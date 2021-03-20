using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
/*using System.*/
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
namespace ProductsApp.PL
{
    public partial class FRM_CATEGORY : Form
    {
        SqlConnection sql = new SqlConnection(@"Data Source = rania; Initial Catalog = Products_db; Integrated Security = true;");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingManagerBase bmb;

        SqlCommandBuilder cmdb;
        public FRM_CATEGORY()
        {
            InitializeComponent();
            da = new SqlDataAdapter("SELECT cat_id as 'معرف الصنف' ,cat_description  as   'وصف الصنف' FROM Cateogries", sql);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
             textBox1.DataBindings.Add("text", dt,"معرف الصنف");
            
             textBox2.DataBindings.Add("text", dt,"وصف الصنف");
            //  bmb = new BindingManagerBase();
            bmb = this.BindingContext[dt];
            Lblposition.Text = (bmb.Position + 1) + "/" + bmb.Count;

        }

        private void label3_Click(object sender, EventArgs e)
        {
      
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            Lblposition.Text = (bmb.Position + 1) + "/" + bmb.Count;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            newBTN.Enabled = false;
            addBTN.Enabled = true;
       
            int id = bmb.Count+1;

            DataRow lastRow = dt.Rows[dt.Rows.Count - 1];

           string text=lastRow[0].ToString();
            int t = int.Parse(text);
            t += 1;
            textBox1.Text = t.ToString() ;
        /*        int.Parse(dt.Rows[PP])+1;*/
            textBox2.Focus();
            Lblposition.Text = (bmb.Count) + "/" +( bmb.Count+1);
            // Lblposition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

  

        private void button5_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            Lblposition.Text = (bmb.Position + 1) + "/" + bmb.Count;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            Lblposition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            Lblposition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void addBTN_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("add successfullty", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            addBTN.Enabled = false;
            newBTN.Enabled = true;
            //   Lblposition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("DELETE successfullty", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
          //  Lblposition.Text = (bmb.Position + 1) + "/" + bmb.Count;

        }

        private void modifyBTN_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("UPDATE successfullty", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        
        }

        private void printallCate_Click(object sender, EventArgs e)
        {
            Reporting.RPT_ALL_CATEGORY report = new Reporting.RPT_ALL_CATEGORY();
            Reporting.FRM_RPT_PRODUCT frm = new Reporting.FRM_RPT_PRODUCT();
            report.Refresh();
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
        }

        private void printCurrentCat_Click(object sender, EventArgs e)
        {
            Reporting.RPT_SINGLE_CATEGORY report = new Reporting.RPT_SINGLE_CATEGORY();
            Reporting.FRM_RPT_PRODUCT frm = new Reporting.FRM_RPT_PRODUCT();
            report.SetParameterValue("@ID", int.Parse(textBox1.Text));
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
        }

        private void saveCategories_Click(object sender, EventArgs e)
        {

            Reporting.RPT_SINGLE_CATEGORY report2 = new Reporting.RPT_SINGLE_CATEGORY();
            ////
            ExportOptions export = new ExportOptions();
            PdfFormatOptions excelformat = new PdfFormatOptions();
            DiskFileDestinationOptions dfoption = new DiskFileDestinationOptions();
            
            export = report2.ExportOptions;
            dfoption.DiskFileName = @"Desktop:\categories.pdf";
            export.ExportFormatType = ExportFormatType.PortableDocFormat;
            export.ExportDestinationType = ExportDestinationType.DiskFile;
            export.ExportFormatOptions = excelformat;
            report2.SetParameterValue("@ID", int.Parse(textBox1.Text));
            report2.ExportToDisk(ExportFormatType.PortableDocFormat, "E:\\categories.pdf");

            MessageBox.Show("list export successfully", "export", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
